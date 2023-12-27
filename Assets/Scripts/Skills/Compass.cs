using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class Compass : MonoBehaviour
{
    float startScalingDistance = 30f;
    float minScalingDistance = 15f;
    float distanceFromPlayer = 5f;
    float heightAboveGround = 0f;

    Transform player;
    Transform targetTotem;
    Light compassLight;
    bool isOnCooldown = false;
    float lastActivationTime;

    public bool compassActive = true;
    public float cooldownTime = 10f;
    public TextMeshProUGUI cooldownText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        compassLight = GetComponent<Light>();
        FindClosestTotem();
    }

    void Update()
    {
        UpdateCooldown();

        if (isOnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("cooldown");
            }
        } // Verificación cooldown

        if (!isOnCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateCompass();
                compassActive = true;
            }
        }

        if (compassActive)
        {
            if (targetTotem == null)
            {
                FindClosestTotem();
                return;
            }

            float distanceToTotem = Vector3.Distance(player.position, targetTotem.position);

            float scale = Mathf.Lerp(1f, 0f, Mathf.InverseLerp(startScalingDistance, minScalingDistance, distanceToTotem));
            transform.localScale = new Vector3(scale, scale, scale);

            if (compassLight != null)
            {
                compassLight.intensity = scale * 10f;
            }

            Vector3 targetPosition = new Vector3(targetTotem.position.x, player.position.y + heightAboveGround, targetTotem.position.z);
            Vector3 directionToTotem = targetPosition - player.position;
            Vector3 desiredPosition = player.position + directionToTotem.normalized * distanceFromPlayer;

            transform.LookAt(targetPosition);
            transform.position = desiredPosition;
        }
    }

    void ActivateCompass()
    {
        isOnCooldown = true;
        lastActivationTime = Time.time;
    }

    void UpdateCooldown()
    {
        if (isOnCooldown)
        {
            float tiempoRestante = cooldownTime - (Time.time - lastActivationTime);
            tiempoRestante = Mathf.Max(0f, tiempoRestante);

            cooldownText.text = tiempoRestante.ToString("F2");

            if (Time.time - lastActivationTime >= cooldownTime)
            {
                isOnCooldown = false;
                cooldownText.text = "0.00";
            }
        }
    }

    void FindClosestTotem()
    {
        GameObject[] totems = GameObject.FindGameObjectsWithTag("ActiveTotem");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject totem in totems)
        {
            float distance = Vector3.Distance(player.position, totem.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                targetTotem = totem.transform;
            }
        }
    }
}
