using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI hpText;

    float hp;

    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (hp > 100)
        {
            hp = 100;
        } // Evita que la vida supere el 100%
        if (hp <= 0)
        {
            Time.timeScale = 0;
        }
        UpdateHealthUI();
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
        hpText.text = hp.ToString() + "%";
    }
}
