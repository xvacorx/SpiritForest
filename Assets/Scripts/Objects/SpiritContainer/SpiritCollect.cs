using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpiritCollect : MonoBehaviour
{
    [SerializeField] GameObject emptyContainer;
    public Compass compass;
    public void CollectSpirit()
    {
        compass.enabled = false;
        Instantiate(emptyContainer, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
