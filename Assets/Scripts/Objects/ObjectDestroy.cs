using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public float DestroyDelay;
    private void Start()
    {
        Destroy(gameObject, DestroyDelay);
    }
}
