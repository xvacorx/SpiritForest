using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Slider healthSlider;

    float hp;

    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Time.timeScale = 0;
        }
        UpdateHealthUI();
        Debug.Log(hp);
    }

    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
        UpdateHealthUI();
    }

    public void Curar(float heal)
    {
        hp += heal;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;
    }
}
