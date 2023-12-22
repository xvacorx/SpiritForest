using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public float velocidadSeguimiento = 5.0f;
    public float fuerzaEmpuje = 10.0f;
    public LayerMask capaJugador;

    private Transform jugador;

    private void Start()
    {
        // Buscar al jugador al comienzo
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Seguir al jugador
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadSeguimiento * Time.deltaTime, Space.World);

        // Rotar hacia la direcci�n del jugador
        transform.LookAt(jugador);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si ha tocado al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener la direcci�n contraria a la que se dirig�a el Bull
            Vector3 direccionContraria = (transform.position - jugador.position).normalized;

            // Aplicar fuerza de empuje en la direcci�n contraria
            GetComponent<Rigidbody>().AddForce(direccionContraria * fuerzaEmpuje, ForceMode.Impulse);

            // Aplicar da�o al jugador (suponiendo que el jugador tiene un script StatsManager)
            StatsManager statsManager = collision.gameObject.GetComponent<StatsManager>();
            if (statsManager != null)
            {
                //statsManager.RecibirDanio();
            }
        }
    }
}
