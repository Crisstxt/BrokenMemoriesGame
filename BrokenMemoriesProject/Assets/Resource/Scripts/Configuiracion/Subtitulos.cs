using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Subtitulos : MonoBehaviour
{
    string[] palabras = new string[] {"Vivir", "es tener coraje", "Pues en este mundo en constante cambio y desafío, nos recuerda la fragilidad y fuerza  de la vida."
    ,"Cómo la conciencia de nuestra propia mortalidad nos impulsa hacia delante o nos arrastra hacia el miedo."
    ,"En este despiadado escenario, donde las certezas se desvanecen y los cimientos de la existencia se tambalean."
    ,"Es fácil sucumbir al miedo, cada respiración sirve como un recordatorio rotundo de nuestra presencia fugaz en este vasto cosmos."
    ,"Aquí, en este momento de oscuridad, donde la búsqueda del sentido de la vida se desvanece y la desesperación amenaza con engullirnos"
    ,"El amor se convierte en odio y el odio se convierte en destrucción"
    ,"En medio de esta tormenta, surge una elección crucial: dejarnos arrastrar por la marea de la desesperación o aferrarnos con todas nuestras fuerzas a la esperanza"
    ,"En este escenario trágico, nuestras elecciones cobran un significado trascendental"
    ,"Cada paso, cada palabra, cada acción puede llevarnos más cerca del abismo o elevarnos hacia un lugar de luz"
    ,"Coraje y esperanza es lo único que queda en un mundo donde los recuerdos están rotos"} ;

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
 