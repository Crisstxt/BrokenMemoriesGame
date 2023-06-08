using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ChangeNumber : StateMachineBehaviour
{
    EnemigosController enemigosController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigosController = animator.GetComponent<EnemigosController>();
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemigosController.CambiarRandomNum();
    }
}
