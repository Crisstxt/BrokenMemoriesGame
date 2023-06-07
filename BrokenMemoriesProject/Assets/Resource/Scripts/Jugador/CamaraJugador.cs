using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CamaraJugador : MonoBehaviour
{
    private Transform player;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private string estiloJugador;
    private GameObject[] jugadores;

    [Header("Música")]
    [SerializeField] private AudioClip musicaDerrota;
    [SerializeField] private AudioMixer mixer;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        estiloJugador = PlayerPrefs.GetString("Estilo");

        jugadores = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject jugador in jugadores)
        {
            if (!jugador.name.Equals(estiloJugador))
            {
                jugador.SetActive(false);
            }
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
            if (player.position.y > transform.position.y || player.position.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            }

            if (player.position.x > transform.position.x || player.position.x < transform.position.x)
            {
                transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            }

            if (player.GetComponent<Jugador>().estaMuerto)
            {
                mixer.SetFloat("Volumen", -35f);
                audioSource.loop = true;
                audioSource.PlayOneShot(musicaDerrota);
           
            }
    }

    void LateUpdate()
    {
        Vector3 posActual = transform.position;

        posActual.y = Mathf.Clamp(player.position.y, minPosition.y, maxPosition.y);

        transform.position = posActual;
    }
}
