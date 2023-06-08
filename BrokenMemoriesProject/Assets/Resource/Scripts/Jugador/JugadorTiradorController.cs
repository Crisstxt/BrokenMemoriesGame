using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorTiradorController : MonoBehaviour
{
    [Header("Controlador Tiros")]
    [SerializeField] private Transform controladorTiros;
    [SerializeField] private GameObject bala;
    [SerializeField] float Ataquerate = 5f;
    private float proximoAtaque = 0f;
    private Animator animator;

    [Header("Sonidos")]
    [SerializeField] AudioClip sonidoDisparo;
    private AudioSource audioSource;
    private Jugador pj;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        pj = GetComponent<Jugador>();
    }

    void Update()
    {
        if (Time.time >= proximoAtaque)
        {
           if (Input.GetKeyDown(KeyCode.Mouse0) && pj.GetEnSuelo())
           {
            Disparar();
            proximoAtaque = Time.time + 1f / Ataquerate;
           }
        }
         
    }

    public void Disparar()
    {
        audioSource.PlayOneShot(sonidoDisparo);
        animator.SetTrigger("Shoot");
        Instantiate(bala, controladorTiros.position, controladorTiros.rotation);
    }


}
