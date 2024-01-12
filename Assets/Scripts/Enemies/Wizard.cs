using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public float velocidadMovimiento = 2.0f;
    public float alturaSuelo = 5.0f;
    public float frecuenciaDisparo = 5.0f;
    public GameObject proyectilPrefab;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("DispararProyectil", 3f, frecuenciaDisparo);
    }

    private void Update()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        Vector3 destino = jugador.position - 15f * direccion;

        RaycastHit hit;
        if (Physics.Raycast(destino, Vector3.down, out hit, Mathf.Infinity))
        {
            destino.y = hit.point.y + alturaSuelo;
        }

        transform.position = Vector3.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);
        transform.LookAt(jugador);
    }

    private void DispararProyectil()
    {
        Instantiate(proyectilPrefab, transform.position, Quaternion.LookRotation(jugador.position - transform.position));
    }
}
