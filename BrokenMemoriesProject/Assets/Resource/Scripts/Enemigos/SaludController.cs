using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludController : MonoBehaviour
{
    [Header("Estadisticas Base")]
    public float saludMaxima;
    public float saludActual;
    private bool isDeath;
    private Animator animator;

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoHit;
    [SerializeField] private AudioClip sonidoMuerte;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        saludActual = saludMaxima;
        isDeath = false;
        animator = GetComponent<Animator>();
    }

    public float GetSaludActual()
    {
        return saludActual;
    }

  

    public bool GetIsDeath()
    {
        return isDeath;
    }

    public void ObtenerDanyo(float danyo)
    {
        animator.SetTrigger("Hit");
        audioSource.PlayOneShot(sonidoHit);

        saludActual -= danyo;

        if (saludActual <= 0)
        {
            isDeath = true;
            Muerte();          
        }
    }

    public void Muerte()
    {
        audioSource.PlayOneShot(sonidoMuerte);
        animator.SetBool("isDead", isDeath);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        this.enabled = false;
    }

   
  
}
