using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int vida = 100;
    public GameObject efectoAlMorirPrefab;
    public void RecibirDanio(int cantidadDanio)
    {
        vida -= cantidadDanio;
        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Instantiate(efectoAlMorirPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}