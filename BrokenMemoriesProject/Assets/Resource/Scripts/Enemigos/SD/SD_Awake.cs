using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_Awake : StateMachineBehaviour
{
    EnemigosController enemigosController;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigosController = animator.GetComponent<EnemigosController>();
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigosController.SetEstaActivado(true);
    }

}
