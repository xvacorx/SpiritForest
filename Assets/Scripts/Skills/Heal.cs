using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    StatsManager statsManager;
    private void Start()
    {
        statsManager = FindObjectOfType<StatsManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            if (statsManager != null)
            {
                statsManager.Curar(10);
                Destroy(collision.gameObject);
            }
        }
    }
}
