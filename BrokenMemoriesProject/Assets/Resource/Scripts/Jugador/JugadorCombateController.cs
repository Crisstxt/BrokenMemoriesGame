using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorCombateController : MonoBehaviour
{
    [Header("Estadisticas Base")]
    [SerializeField] private float DanyoAtaquePrimario;
    [SerializeField] private float DanyoAtaqueSecundario;
    private float dmg;

    [Header("Control Ataque")]
    [SerializeField] private Transform AttackController;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] private float RangoAtaque = 0.5f;
    [SerializeField] float Ataquerate = 5f;
    private float proximoAtaque = 0f;
    private Animator animator;
    public bool isBlock;
    private KeyCode key;

    [Header("Habilidades")]
    [SerializeField] private bool tieneCombo;
    public int indexCombo;
    public bool atacando;

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoAtaque;
    [SerializeField] private AudioClip sonidoCarga;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.anyKeyDown)
        {
            key = ObtenerTecla();
            CombateJugador(key);
        }
    }

    public void CombateJugador(KeyCode x)
    {
        if (Time.time >= proximoAtaque)
        {

            switch (x)
            {
                case (KeyCode.Mouse0):
                    dmg = DanyoAtaquePrimario;
                        if (tieneCombo)
                        {                       
                            Combo();
                        } else
                        {
                            animator.SetTrigger("0");
                            audioSource.PlayOneShot(sonidoAtaque);
                            proximoAtaque = Time.time + 1f / Ataquerate;
                        }
                    break;

                case (KeyCode.Mouse1):
                    audioSource.PlayOneShot(sonidoCarga);
                    dmg = DanyoAtaqueSecundario;             
                    animator.SetTrigger("Charge");
                    proximoAtaque = Time.time + 1f / Ataquerate;
                    TerminarCombo();
                    break;

                case (KeyCode.LeftControl):
                    animator.SetTrigger("Block");
                    isBlock = true;
                    proximoAtaque = Time.time + 1f / Ataquerate;
                    TerminarCombo();
                    break;

            }
        }
    }

    public KeyCode ObtenerTecla()
    {
        foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }

        return KeyCode.None;
    }

    public void Combo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !atacando)
        {
            atacando = true;
            audioSource.PlayOneShot(sonidoAtaque);
            animator.SetTrigger("" + indexCombo);

        }
    }

    public void ComenzarCombo()
    {
        atacando = false;
        if(indexCombo < 3)
        {
            indexCombo++;
        }
    }

    public void TerminarCombo()
    {
        atacando = false;
        indexCombo = 0;
    }



    public float GetDmgPrimario()
    {
        return DanyoAtaquePrimario;
    }

    public float GetDmgSecundario()
    {
        return DanyoAtaqueSecundario;
    }

    public void SetDmgPrimario(float newdmg)
    {
        DanyoAtaquePrimario = newdmg;
    }

    public void SetDmgSecundario(float newdmg)
    {
        DanyoAtaqueSecundario = newdmg;     
    }

    public float GetActualDMG()
    {
        return dmg;
    }
    public void Ataque()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackController.position, RangoAtaque, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
                enemy.GetComponent<SaludController>().ObtenerDanyo(dmg);    
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackController.position, RangoAtaque);
        print("fa");
    }

}
