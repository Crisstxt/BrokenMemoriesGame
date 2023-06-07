using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoParallax : MonoBehaviour
{
    private Transform camara;
    private Vector3 PosPreviaCamara;
    [Range(0, 1f)] [SerializeField] float ParallaxVel;
    private float anchoSprite, posicionIncial;

    void Start()
    {
        camara = Camera.main.transform;
        PosPreviaCamara = camara.position;
        anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
        posicionIncial = transform.position.x;
    }

    
    void LateUpdate()
    {
        float deltaX = (camara.position.x - PosPreviaCamara.x) * ParallaxVel;
        float movCamaraCapa = camara.position.x * (1 - ParallaxVel);
        transform.Translate(new Vector3(deltaX, 0, 0));
        PosPreviaCamara = camara.position;

        if (movCamaraCapa > posicionIncial + anchoSprite)
        {
            transform.Translate(new Vector3(anchoSprite, 0, 0));
            posicionIncial += anchoSprite;
        }
        else if (movCamaraCapa < posicionIncial - anchoSprite)
        {
            transform.Translate(new Vector3(-anchoSprite, 0, 0));
            posicionIncial -= anchoSprite;
        }
    }


}
