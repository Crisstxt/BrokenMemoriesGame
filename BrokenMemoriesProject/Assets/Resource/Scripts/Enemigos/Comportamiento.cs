using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento : MonoBehaviour
{
    /*Script de comportamiento*/


    [Header("Estadisticas Base")]
    public float velocidadMov;
    public float mov;
    private bool mirandoDerecha = true;

    [Header("Cazar")]
    [SerializeField] private Transform player;
    [SerializeField] private float distanceChase;
    private bool isChasing;
    public bool isActivated = false;
    public bool isAttacking = false;


    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (isChasing)
        {
            if (!isActivated)
            {
                animator.SetTrigger("Activated");
            }

            if (!isAttacking)
            {
                if (transform.position.x > player.position.x && isActivated)
                {
                    mov = velocidadMov;
                    transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.left * mov * Time.deltaTime;
                    animator.SetFloat("Horizontal", Mathf.Abs(mov));
                }

                if (transform.position.x < player.position.x && isActivated)
                {
                    mov = velocidadMov;
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.right * mov * Time.deltaTime;
                    animator.SetFloat("Horizontal", Mathf.Abs(mov));
                }
            }

        }


        if (Vector2.Distance(transform.position, player.position) < distanceChase || player.position.y == transform.position.y)
        {
            isChasing = true;
        } else
        {
            isChasing = false;
            mov = 0;
        }


    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
