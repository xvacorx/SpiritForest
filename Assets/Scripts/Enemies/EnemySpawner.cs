using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemigosPrefabs;
    int minEnemigos = 3;
    int maxEnemigos = 5;
    public float radioMinimo = 10f;
    public float radioMaximo = 25f;

    public void SpawnEnemies()
    {
        int numEnemigos = Random.Range(minEnemigos, maxEnemigos + 1);

        for (int i = 0; i < numEnemigos; i++)
        {
            GenerarEnemigo();
        }
    }

    private void GenerarEnemigo()
    {
        GameObject enemigoPrefab = enemigosPrefabs[Random.Range(0, enemigosPrefabs.Length)];

        float angulo = Random.Range(0f, 2f * Mathf.PI);
        float radio = Random.Range(radioMinimo, radioMaximo);
        float x = transform.position.x + Mathf.Cos(angulo) * radio;
        float z = transform.position.z + Mathf.Sin(angulo) * radio;
        float y = transform.position.y + Random.Range(1f, 10f);

        Vector3 posicionEnemigo = new Vector3(x, y, z);
        Instantiate(enemigoPrefab, posicionEnemigo, Quaternion.identity);
    }
}