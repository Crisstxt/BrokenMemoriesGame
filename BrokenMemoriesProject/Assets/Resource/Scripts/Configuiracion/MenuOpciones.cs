using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{

    public AudioMixer audioMusic;
    public AudioMixer audioSFX;
    public void ConfPantCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void cambiarVolumenMusica(float volumen)
    {
        audioMusic.SetFloat("Volumen", volumen); 
    }

    public void cambiarVolumenSFX(float volumen)
    {
        audioSFX.SetFloat("Volumen", volumen);
    }





}
