using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private Toggle shooter;
    [SerializeField] private Toggle melee;

    private string difselecionada;
    private string estilo;


    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetString("Dificultad", difselecionada);
        PlayerPrefs.SetString("Estilo", estilo);
    }

    public void Salir()
    {
        Debug.Log("Saliendo!");
        Application.Quit();
    }

    public void OnClickButton(Button btn)
    {
        if (!shooter.isOn && !melee.isOn)
        {
            txt.text = "Tienes que escoger uno";
            txt.color = Color.red;
            return;
        } else
        {
            if (shooter.isOn)
            {
                estilo = Constantes.JUGADOR_SHOOTER;               
            } else if (melee.isOn)
            {
                estilo = Constantes.JUGADOR_MELEE;
            }
        }

        if (btn.name.Equals(Constantes.DIFICULTAD_FACIL))
        {
            difselecionada = Constantes.DIFICULTAD_FACIL;
            Jugar();
        }

        if (btn.name.Equals(Constantes.DIFICULTAD_NORMAL))
        {
            difselecionada = Constantes.DIFICULTAD_NORMAL;
            Jugar();
        }

        if (btn.name.Equals(Constantes.DIFICULTAD_DIFICIL))
        {
            difselecionada = Constantes.DIFICULTAD_DIFICIL;
            Jugar();
        }
    }
}