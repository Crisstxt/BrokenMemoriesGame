using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultadControler : MonoBehaviour
{
    public string dificultadPasada;
    public string estilo;
    void Start()
    {
        dificultadPasada = PlayerPrefs.GetString("Dificultad");
        estilo = PlayerPrefs.GetString("Estilo");
        Debug.Log("Dificulatad Pasada |" + dificultadPasada + "| Estilo pasado |"+ estilo + "|");
    }

    

}
