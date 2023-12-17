using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public float startScalingDistance = 30f;
    public float minScalingDistance = 15f;
    public float distanceFromPlayer = 5f;
    public float heightAboveGround = 0f;

    private Transform player;
    private Transform targetTotem;
    private Light compassLight;

    private void Awake()
    {
        this.enabled = false;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        compassLight = GetComponent<Light>();  // Asignar la luz al inicio
        FindClosestTotem();
    }

    void Update()
    {
        if (targetTotem == null)
        {
            FindClosestTotem();
            return;
        }

        float distanceToTotem = Vector3.Distance(player.position, targetTotem.position);

        // Escalar la brújula gradualmente hacia cero a medida que te acercas al totem
        float scale = Mathf.Lerp(1f, 0f, Mathf.InverseLerp(startScalingDistance, minScalingDistance, distanceToTotem));
        transform.localScale = new Vector3(scale, scale, scale);

        // Ajustar la intensidad de la luz según la escala
        if (compassLight != null)
        {
            compassLight.intensity = scale * 10f;
        }

        // Actualizar posición de la brújula
        Vector3 targetPosition = new Vector3(targetTotem.position.x, player.position.y + heightAboveGround, targetTotem.position.z);
        Vector3 directionToTotem = targetPosition - player.position;
        Vector3 desiredPosition = player.position + directionToTotem.normalized * distanceFromPlayer;

        transform.LookAt(targetPosition);
        transform.position = desiredPosition;
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