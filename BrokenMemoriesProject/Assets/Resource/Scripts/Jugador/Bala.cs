using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dmg;

    private Jugador pj;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        pj = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();

        if (pj.GetOrientacion())
        {
            transform.localScale = new Vector3(1, 1, 1);
            velocidad = velocidad * 1;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            velocidad = velocidad * -1;
        }
    }

    void Update()
    {
        Destroy(gameObject, 4);
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<SaludController>().ObtenerDanyo(dmg);
            velocidad = 0;
            animator.SetTrigger("Destroy");
            Destroy(gameObject, 0.5f);
        }
    }


}
