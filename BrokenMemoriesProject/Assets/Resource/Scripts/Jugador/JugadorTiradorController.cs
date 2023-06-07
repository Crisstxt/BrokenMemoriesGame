using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorTiradorController : MonoBehaviour
{
    [Header("Controlador Tiros")]
    [SerializeField] private Transform controladorTiros;
    [SerializeField] private GameObject bala;
    private Animator animator;

    [Header("Sonidos")]
    [SerializeField] AudioClip sonidoDisparo;
    private AudioSource audioSource;


    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        audioSource.PlayOneShot(sonidoDisparo);
        animator.SetTrigger("Shoot");
        Instantiate(bala, controladorTiros.position, controladorTiros.rotation);
    }
}
