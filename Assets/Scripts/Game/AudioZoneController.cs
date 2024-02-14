using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZoneController : MonoBehaviour
{
    public GameObject globalAudioSource;
    public GameObject localAudioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            globalAudioSource.SetActive(false);
            localAudioSource.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            globalAudioSource.SetActive(true);
            localAudioSource.SetActive(false);
        }
    }
}
