using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public float velocidadSeguimiento = 2.0f;
    public float frecuenciaExplosion = 2.5f;
    public GameObject explosionPrefab;
    public float radioDanio = 5f;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("RealizarExplosion", 0f, frecuenciaExplosion);
    }

    private void Update()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadSeguimiento * Time.deltaTime, Space.World);
        transform.LookAt(jugador);
    }

    private void RealizarExplosion()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (Vector3.Distance(transform.position, jugador.position) <= radioDanio)
        {
            StatsManager statsManager = jugador.GetComponent<StatsManager>();
            if (statsManager != null)
            {
                statsManager.RecibirDanio(10);
            }
        }
    }
}
