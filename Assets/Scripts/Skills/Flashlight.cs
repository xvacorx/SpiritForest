using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
        flashlight.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
            Debug.Log("Linterna");
        }
    }

    private void ToggleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
