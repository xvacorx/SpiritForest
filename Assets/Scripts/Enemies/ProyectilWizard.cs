using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilWizard : MonoBehaviour
{
    public float velocidadProyectil = 10.0f;
    public int danioProyectil = 20;
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
            if (statsManager != null)
            {
                //statsManager.RecibirDanio(danioProyectil);
            }
            DestruirProyectil();
        }
        else
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
