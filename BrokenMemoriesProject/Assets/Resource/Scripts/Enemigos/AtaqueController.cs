using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueController : MonoBehaviour
{
    [Header("Estadisticas Base")]
    [SerializeField] private float DanyoAtaquePrimario;
    [SerializeField] private float DanyoAtaqueSecundario;

    [Header("Control Ataque")]
    [SerializeField] private Transform AttackController;
    [SerializeField] Transform jugador;
    [SerializeField] private float RangoAtaque = 3f;
    [SerializeField] float Ataquerate = 3f;
    private float numeroAleatorio;
    public LayerMask attackMask;

    private float proximoAtaque = 0f;
    private Animator animator;
    private Rigidbody2D rb;
    private Comportamiento ctp;


    [Header("Control Escudos")]
    [SerializeField] private bool tieneEscudo;
    public bool shieldUp;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ctp = GetComponent<Comportamiento>();
        obtenerNumero();
    }

    
    void Update()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(AttackController.position, RangoAtaque, attackMask);

        if (!tieneEscudo && colInfo != null)
        {
            ctp.mov = 0;
            StartCoroutine(EsperarYAtacar(2f));
        }

        if (tieneEscudo && colInfo != null)
        {
            ctp.mov = 0;
            StartCoroutine(EsperarYAtacarAleatorio(2f));
        }
    }

    IEnumerator EsperarYAtacar(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetTrigger("Attack");
    }

    IEnumerator EsperarYAtacarAleatorio(float delay)
    {
        yield return new WaitForSeconds(delay);

        AtaqueAleatorio(numeroAleatorio);
    }


    public void AtaqueEnemigo()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(AttackController.position, RangoAtaque, attackMask);
        if (colInfo != null && !jugador.GetComponent<JugadorCombateController>().isBlock)
        {
            jugador.GetComponent<Jugador>().ObtenerDanyo(DanyoAtaquePrimario);       
        }
    }

    public void AtaqueAleatorio(float num)
    {
        switch (num)
        {
            case 1:
                animator.SetTrigger("Attack");
                break;
            case 2:
                shieldUp = true;
                animator.SetTrigger("shieldUp");
                break;
        }
    }
    public void obtenerNumero()
    {
        numeroAleatorio = Random.Range(1,2+1);
    }

    public float GetNumAle()
    {
        return numeroAleatorio;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackController.position, RangoAtaque);
    }

}
