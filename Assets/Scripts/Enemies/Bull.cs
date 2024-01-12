using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public float velocidadSeguimiento = 5.0f;
    public float fuerzaEmpuje = 10.0f;

    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        transform.Translate(direccion * velocidadSeguimiento * Time.deltaTime, Space.World);

        transform.LookAt(jugador);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direccionContraria = (transform.position - jugador.position).normalized;

            GetComponent<Rigidbody>().AddForce(direccionContraria * fuerzaEmpuje, ForceMode.Impulse);

            StatsManager statsManager = collision.gameObject.GetComponent<StatsManager>();
            if (statsManager != null)
            {
                statsManager.RecibirDanio(10);
            }
        }
    }
}
