using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotemManager : MonoBehaviour
{
    public TMP_Text totemCountText;
    public string totemTag = "ActiveTotem";
    private void Start()
    {
        GetTotalTotems();
    }
    void Update()
    {
        UpdateTotemCountText();
    }

    void UpdateTotemCountText()
    {
        GameObject[] totems = GameObject.FindGameObjectsWithTag(totemTag);
        int totalTotems = totems.Length;
        if (totalTotems > 0)
        {
            totemCountText.text = "Totems Remains: " + totalTotems;
        }
        else { totemCountText.text = "All Totems collected!"; }
    }
    int GetTotalTotems()
    {
        GameObject[] totems = GameObject.FindGameObjectsWithTag(totemTag);
        return totems.Length;
    }
}
