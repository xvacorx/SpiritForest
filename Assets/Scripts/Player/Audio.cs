using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource globalAudioSource;
    public AudioSource battleAudioSource;
    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            battleAudioSource.enabled = true;
        }
        else
        {
            battleAudioSource.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out AudioSource audio))
        {
            audio.enabled = true;
            globalAudioSource.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out AudioSource audio))
        {
            audio.enabled = false;
            globalAudioSource.enabled = true;
        }
    }
}