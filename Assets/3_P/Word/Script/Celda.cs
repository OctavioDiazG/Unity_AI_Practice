using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Celda : MonoBehaviour
{
    public Image fill;
    public Text texto;
    public bool util;

    private void Awake()
    {
        fill = GetComponent<Image>();
        texto = GetComponentInChildren<Text>();
    }
    // Start is called before the first frame update
    public void correcta()
    {
        fill.color = Color.green;
        
    }
    public void semiCorrecta()
    {
        fill.color = Color.yellow;
        util = true;
        
    }
    public void incorrecta()
    {
        fill.color = Color.gray;
        util = false;
    }
}
