using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SpiritCollect spirit))
        {
            spirit.CollectSpirit();
        }
    }
}
