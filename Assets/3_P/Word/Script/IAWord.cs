using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAWord : MonoBehaviour
{
    public string[] palabras;

    public Tablero tablero;
    public string palabra;

    private void Awake()
    {
        tablero = GetComponent<Tablero>();
    }

    // Start is called before the first frame update
    void Start()
    {
        palabras = tablero.verdaderasPalabras;
        int indiceAleatorio = UnityEngine.Random.Range(0, palabras.Length);
        palabra = palabras[indiceAleatorio];
    }

    
}
