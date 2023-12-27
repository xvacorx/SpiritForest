using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StatsManager : MonoBehaviour
{
    float hp;
    private void Start()
    {
        hp = 100;
    }
    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
    }
    public void Curar(float heal)
    {
        hp += heal;
    }
}
