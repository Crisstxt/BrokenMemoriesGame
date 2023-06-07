using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraVidaController : MonoBehaviour
{
    private Slider slide;


    void Start()
    {
        slide = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vida)
    {
        slide.maxValue = vida;
    }

    public void CambiarVidaActual(float vida)
    {
        slide.value = vida;
    }
    
    public void InicializarBarraVida(float vida)
    {
        CambiarVidaMaxima(vida);
        CambiarVidaActual(vida);
    }
}
