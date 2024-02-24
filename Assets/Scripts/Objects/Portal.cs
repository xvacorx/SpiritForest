using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    private float targetHeight = 43.5f;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("ActiveTotem").Length == 0)
        {
            MovePortalToTargetHeight();
        }
        else
        {
            MovePortalToZeroHeight();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    void MovePortalToTargetHeight()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetHeight, transform.position.z), Time.deltaTime * 5f);
    }

    void MovePortalToZeroHeight()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
    }
}
