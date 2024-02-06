using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollect : MonoBehaviour
{
    public string scene;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SpiritCollect spirit))
        {
            spirit.CollectSpirit();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
