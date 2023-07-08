using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fila : MonoBehaviour
{
    public Celda[] celdas;
    public char[] word;
    

    private void Awake()
    {
        celdas = GetComponentsInChildren<Celda>();
        word = new char[celdas.Length];
    }

    public void cambiarLetra(int current)
    {
        celdas[current].texto.text = "" + word[current];
    }
}
