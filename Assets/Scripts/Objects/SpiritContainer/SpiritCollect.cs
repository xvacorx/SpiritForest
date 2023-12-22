using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCollect : MonoBehaviour
{
    [SerializeField] GameObject emptyContainer;
    GameObject compass;
    Compass compassScript;
    EnemySpawner spawner;
    private void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        compass = GameObject.Find("Compass");
        compassScript = compass.GetComponent<Compass>();
    }

    public void CollectSpirit()
    {
        if (compassScript != null)
        {
            compassScript.enabled = false;
        }

        spawner.SpawnEnemies();
        Instantiate(emptyContainer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}