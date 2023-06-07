using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Subtitulos : MonoBehaviour
{
    string[] palabras = new string[] {"Vivir", "es tener coraje", "Pues en este mundo en constante cambio y desaf�o, nos recuerda la fragilidad y fuerza  de la vida."
    ,"C�mo la conciencia de nuestra propia mortalidad nos impulsa hacia delante o nos arrastra hacia el miedo."
    ,"En este despiadado escenario, donde las certezas se desvanecen y los cimientos de la existencia se tambalean."
    ,"Es f�cil sucumbir al miedo, cada respiraci�n sirve como un recordatorio rotundo de nuestra presencia fugaz en este vasto cosmos."
    ,"Aqu�, en este momento de oscuridad, donde la b�squeda del sentido de la vida se desvanece y la desesperaci�n amenaza con engullirnos"
    ,"El amor se convierte en odio y el odio se convierte en destrucci�n"
    ,"En medio de esta tormenta, surge una elecci�n crucial: dejarnos arrastrar por la marea de la desesperaci�n o aferrarnos con todas nuestras fuerzas a la esperanza"
    ,"En este escenario tr�gico, nuestras elecciones cobran un significado trascendental"
    ,"Cada paso, cada palabra, cada acci�n puede llevarnos m�s cerca del abismo o elevarnos hacia un lugar de luz"
    ,"Coraje y esperanza es lo �nico que queda en un mundo donde los recuerdos est�n rotos"} ;

    public TextMeshProUGUI dialogueText;

    int index;

    void Start()
    {
        DialogoComenzar();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void DialogoComenzar()
    {
        index = 0;

        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        yield return new WaitForSeconds(14f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(2.5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(3f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(8f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(10.5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(11f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(12.5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(13.5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(9.5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(12f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(5f);

        dialogueText.text = palabras[index];
        index++;
        yield return new WaitForSeconds(11f);

        dialogueText.text = palabras[index];
        yield return new WaitForSeconds(10f);
        dialogueText.text = "";
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
 