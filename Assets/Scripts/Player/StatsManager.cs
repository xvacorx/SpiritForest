using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI hpText;
    public GameObject defeat;
    public CameraLook look;

    float hp;
    private void Awake()
    {
        GameObject[] heal = GameObject.FindGameObjectsWithTag("Heal");
        foreach (GameObject healItem in heal)
        {
            Destroy (healItem);
        }

        Time.timeScale = 1.0f;
        defeat.SetActive(false);
        look.enabled = true;
        Cursor.lockState = CursorLockMode.Locked; //Desaparece el cursor
    }
    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
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
            defeat.SetActive(true);
            look.enabled = false;
            Cursor.lockState = CursorLockMode.None; //Aparece el cursor
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