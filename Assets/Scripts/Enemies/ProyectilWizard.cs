using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilWizard : MonoBehaviour
{
    public float velocidadProyectil = 10.0f;
    int danioProyectil = 10;
    public GameObject explosionPrefab;

    private Transform jugador;
    private Vector3 direccion;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        direccion = (jugador.position - transform.position).normalized;
        Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        transform.Translate(direccion * velocidadProyectil * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StatsManager statsManager = other.GetComponent<StatsManager>();
            statsManager.RecibirDanio(danioProyectil);
            DestruirProyectil();
        }
        if (!other.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            DestruirProyectil();
        }
    }

    private void DestruirProyectil()
    {
        Destroy(gameObject);
    }
}