using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public float velocidadMovimiento = 2.0f;
    public float alturaSuelo = 5.0f;  // Altura constante por encima del suelo
    public float frecuenciaDisparo = 5.0f;
    public GameObject proyectilPrefab;

    private Transform jugador;

    private void Start()
    {
        // Buscar al jugador al comienzo
        jugador = GameObject.FindGameObjectWithTag("Player").transform;

        // Iniciar la rutina de disparo
        InvokeRepeating("DispararProyectil", 0f, frecuenciaDisparo);
    }

    private void Update()
    {
        // Moverse hacia la posición a 15 unidades del jugador (en 2D)
        Vector3 direccion = (jugador.position - transform.position).normalized;
        Vector3 destino = jugador.position - 15f * direccion;

        // Utilizar un raycast para mantener la altura constante por encima del suelo
        RaycastHit hit;
        if (Physics.Raycast(destino, Vector3.down, out hit, Mathf.Infinity))
        {
            destino.y = hit.point.y + alturaSuelo;
        }

        transform.position = Vector3.MoveTowards(transform.position, destino, velocidadMovimiento * Time.deltaTime);

        // Rotar hacia la dirección del jugador (opcional)
        transform.LookAt(jugador);
    }

    private void DispararProyectil()
    {
        // Instanciar un proyectil hacia el jugador
        Instantiate(proyectilPrefab, transform.position, Quaternion.LookRotation(jugador.position - transform.position));
    }
}
