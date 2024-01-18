using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDrop : MonoBehaviour
{
    [SerializeField] GameObject heal;
    [SerializeField] float dropProbability = 0.5f;

    private void OnDestroy()
    {
        if (Random.value < dropProbability)
        {
            Instantiate(heal, gameObject.transform.position, Quaternion.identity);
        }
    }
}
