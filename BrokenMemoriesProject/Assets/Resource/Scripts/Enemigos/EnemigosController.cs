using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosController : MonoBehaviour
{
    /*Script del Comportamiento del enemigo, 
     Escirto de forma universal para introducir enemigos de forma sencillo*/

    [Header("Movimiento")]
    [SerializeField] private float velMov;
    [SerializeField] private bool estaActivado;
    private float mov;

    [Header("Acechar")]
    [SerializeField] private float rango;
    [SerializeField] private float rangoAtaque;

    [Header("Combate")]
    [SerializeField] private float danyoAtaquePrimario;
    [SerializeField] private float danyoAtaqueSecundario;
    private float dmg;
    [SerializeField] private bool dosAtaques;
    [SerializeField] private Transform GizmosAtaque;
    [SerializeField] private float rangoGizmos;
    private bool puedeAtacar = true;
    public LayerMask mascaraJugador;
    public int randomNum = 1;
    public bool escudo;

    [Header("Sonidos")]
    [SerializeField] private AudioClip ataquePrimario;
    [SerializeField] private AudioClip ataqueSecundario;
    private AudioSource audioSource;


    private Animator animator;
    private Transform jugador;
    private string dificultad;
    private SaludController saludController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        saludController = GetComponent<SaludController>();
        dificultad = PlayerPrefs.GetString("Dificultad");
        ConfigurarDificultad(dificultad);
    }


    void Update()
    {
        if (estaActivado)
        {
            EncontrarJugador();

            float distanciaPj = Vector3.Distance(transform.position, jugador.position);

            if (distanciaPj <= rango)
            {
                mov = velMov;
                animator.SetFloat("Horizontal", mov);

                if (distanciaPj <= rangoAtaque)
                {
                    mov = 0;
                    AtacarJugador();
                    
                    
                }
                else
                {
                    SeguirJugador();
                }
            } else
            {
                mov = 0;
                animator.SetFloat("Horizontal", mov);
            }
        } else
        {
            animator.SetTrigger("Activated");
        }


        if (saludController.GetIsDeath())
        {
            mov = 0;
            this.enabled = false;
        }
    }

    public void SeguirJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        animator.SetFloat("Horizontal", mov);
        transform.position += direccion * mov * Time.deltaTime;
    }


    public void EncontrarJugador()
    {
        GameObject[] jugadores = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject pj in jugadores)
        {
            if (pj.active)
            {
               jugador = pj.transform;
            }
        }
       
    }


    public void AtacarJugador()
    {
        if (!dosAtaques && puedeAtacar)
        {
            audioSource.PlayOneShot(ataquePrimario);
        dmg = danyoAtaquePrimario;
        animator.SetTrigger("Atacar");
        }

        if (dosAtaques && puedeAtacar)
        {
            puedeAtacar = false;
            switch (randomNum)
            {
                case 1:
                    audioSource.PlayOneShot(ataquePrimario);
                    dmg = danyoAtaquePrimario;
                    animator.SetTrigger("Atacar");              
                    break;
                case 2:
                    audioSource.PlayOneShot(ataqueSecundario);
                    dmg = danyoAtaqueSecundario;
                    animator.SetTrigger("AtacarSecundario");
                    break;
            }
        }

       
    }

    public void Atacar()
    {
        Collider2D collider = Physics2D.OverlapCircle(GizmosAtaque.position, rangoAtaque, mascaraJugador);


        switch (jugador.name)
        {
            case "JugadorShooter":
                jugador.GetComponent<Jugador>().ObtenerDanyo(dmg);
                break;
            case "JugadorMelee":
                    if (collider != null && !jugador.GetComponent<JugadorCombateController>().isBlock)
                    {
                        jugador.GetComponent<Jugador>().ObtenerDanyo(dmg);
                    }    
                break;
        }
    }

    private void PermitirAtaque()
    {
        puedeAtacar = true;
        CambiarRandomNum();
    }

    public void CambiarRandomNum()
    {
        randomNum = Random.Range(1, 2 + 1);
    }

    public bool GetEstaActivado()
    {
        return estaActivado;
    }

    public void SetEstaActivado(bool valor)
    {
        estaActivado = valor;
    }

    public void ConfigurarDificultad(string dificultad)
    {
        switch (dificultad)
        {
            case "NORMAL":
                saludController.saludActual = saludController.saludActual * 1.2f;
                danyoAtaquePrimario = danyoAtaquePrimario * 1.2f;
                danyoAtaqueSecundario = danyoAtaqueSecundario * 1.2f;
                break;
            case "DIFICIL":
                saludController.saludActual = saludController.saludActual * 1.5f;
                danyoAtaquePrimario = danyoAtaquePrimario * 1.5f;
                danyoAtaqueSecundario = danyoAtaqueSecundario * 1.5f;
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(GizmosAtaque.position, rangoGizmos);
    }

}
