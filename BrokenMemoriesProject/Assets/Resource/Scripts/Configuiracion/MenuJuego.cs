using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuJuego : MonoBehaviour
{
    [Header("Paneles")]
    [SerializeField] GameObject panelPausa;
    [SerializeField] GameObject panelVida;

    private bool estaPausado;
    void Start()
    {
        estaPausado = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        if (!estaPausado)
        {
            ScriptsJugador();
            estaPausado = true;
            Time.timeScale = 0f;
            panelPausa.SetActive(estaPausado);
            panelVida.SetActive(false);
        } else if (estaPausado)
        {
            ScriptsJugador();
            estaPausado = false;
            Time.timeScale = 1f;
            panelPausa.SetActive(estaPausado);
            panelVida.SetActive(true);
        }
    } 

    //Habilita o desabilita los scripts de los jugadores
    public void ScriptsJugador()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        var scripts = jugador.GetComponents<MonoBehaviour>();

        foreach (var script in scripts)
        {
            if (!estaPausado)
            {
                script.enabled = false;

            } else if (estaPausado)
            {
                script.enabled = true;
            }
        }
    }
    public void Salir()
    {
        Debug.Log("Saliendo!");
        Application.Quit();
    }

}
