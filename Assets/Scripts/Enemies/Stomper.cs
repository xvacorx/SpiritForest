using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public float velocidadSeguimiento = 2.0f;
    public float frecuenciaExplosion = 5.0f;
    public GameObject explosionPrefab;
    public float radioDanio = 2.5f;

    private Transform jugador;

    private void Start()
    {
        // Buscar al jugador al comienzo
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        // Iniciar la rutina de explosiones
        InvokeRepeating("RealizarExplosion", 0f, frecuenciaExplosion);
    }

    private void Update()
    {
        // Seguir al jugador constantemente
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadSeguimiento * Time.deltaTime, Space.World);

        // Rotar hacia la direcci�n del jugador (opcional)
        transform.LookAt(jugador);
    }

    private void RealizarExplosion()
    {
        // Instanciar la animaci�n de explosi�n
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Aplicar da�o al jugador si est� dentro del radio
        if (Vector3.Distance(transform.position, jugador.position) <= radioDanio)
        {
            // Aplicar da�o al jugador (suponiendo que el jugador tiene un script StatsManager)
            StatsManager statsManager = jugador.GetComponent<StatsManager>();
            if (statsManager != null)
            {
                //statsManager.RecibirDanio();
            }
        }
    }
}
