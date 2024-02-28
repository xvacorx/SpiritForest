using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public GameObject[] areaAudioSources;
    public GameObject globalAudioSource;
    void Update()
    {
        bool playerInsideAnyArea = false;
        foreach (GameObject area in areaAudioSources)
        {
            if (IsPlayerInsideArea(area))
            {
                area.SetActive(true);
                playerInsideAnyArea = true;
            }
            else
            {
                area.SetActive(false);
            }
        }
        if (!playerInsideAnyArea && globalAudioSource != null)
        {
            globalAudioSource.SetActive(true);
        }
        else
        {
            if (globalAudioSource != null)
            {
                globalAudioSource.SetActive(false);
            }
        }
    }

    bool IsPlayerInsideArea(GameObject area)
    {
        Collider areaCollider = area.GetComponent<Collider>();
        if (areaCollider != null && areaCollider is SphereCollider)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            return areaCollider.bounds.Contains(playerPosition);
        }
        return false;
    }
}