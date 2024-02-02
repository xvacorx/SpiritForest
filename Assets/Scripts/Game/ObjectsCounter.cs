using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorObjetos : MonoBehaviour
{
    public string tagObjeto;
    private int cantidadObjetos;
    void Update()
    {

        ActualizarConteo();
    }


    void ActualizarConteo()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag(tagObjeto);
        cantidadObjetos = objetos.Length;
    }

    public int ObtenerCantidadObjetos()
    {
        return cantidadObjetos;
    }
}