using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;

    [Header("Movimiento")]
    [SerializeField] private float velocidadMov;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoMov;
    private float movHorizontal = 0f;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionCaja;
    [SerializeField] private bool enSuelo;
    private bool salto = false;

    [Header("Gameplay")]
    [SerializeField] private float vidaMaxima = 100;
    private float vidaActual;
    [SerializeField] private BarraVidaController cbv;
    public bool estaMuerto;
    [SerializeField] private float contadorTiempoVida;
    private float contvida = 0f;

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoSalto;
    [SerializeField] private AudioClip sonidoDash;
    [SerializeField] private AudioClip sonidoHit;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private AudioClip sonidoCorrer;

    private AudioSource audioSource;

    void Start()
    {
        vidaActual = vidaMaxima;
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        cbv.InicializarBarraVida(vidaMaxima);
        audioSource = GetComponent<AudioSource>();
        estaMuerto = false;
    }

    
    void Update()
    {
        movHorizontal = Input.GetAxis("Horizontal") * velocidadMov;

        animator.SetFloat("Horizontal", Mathf.Abs(movHorizontal));

        animator.SetFloat("VelY", rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
            audioSource.PlayOneShot(sonidoSalto);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.PlayOneShot(sonidoDash);
            animator.SetTrigger("dash");
        }

        Curar();
    }

    void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionCaja, 0f, queEsSuelo);
        animator.SetBool("inGround", enSuelo);

        Mover(movHorizontal * Time.deltaTime, salto);

        salto = false;
    }

    public void ObtenerDanyo(float dmg)
    {
        vidaActual -= dmg;      
        animator.SetTrigger("Hit");
        audioSource.PlayOneShot(sonidoHit);

        cbv.CambiarVidaActual(vidaActual);

        if(vidaActual <= 0)
        {
            estaMuerto = true;
            Muerte();
        }
    }

    public void Curar()
    {
        contvida += Time.deltaTime;

        if (vidaActual < vidaMaxima && contvida >= contadorTiempoVida)
        {
            vidaActual += 5f;
            cbv.CambiarVidaActual(vidaActual);
            contvida = 0f;
        }
    }

    private void Mover(float mov, bool saltar)
    {
        Vector3 velocidadObj = new Vector2(mov, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObj, ref velocidad, suavizadoMov);

        if (mov > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mov < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    public void Muerte()
    {
        audioSource.PlayOneShot(sonidoMuerte);
        animator.SetBool("isDead", estaMuerto);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        this.enabled = false;
    }

    public float GetVidaActual()
    {
        return vidaActual;
    }

    public float GetMovH()
    {
        return Mathf.Abs(movHorizontal);
    }

    public void SetMovH(float mov)
    {
        movHorizontal = mov;
    }

    public bool GetOrientacion()
    {
        return mirandoDerecha;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionCaja);
    }
}
