using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunBehaviour : StateMachineBehaviour
{
    Jugador pj;
    Transform jugadorTransform;
    Animator animator;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jugadorTransform = GameObject.FindGameObjectWithTag("Player").transform;
        pj = jugadorTransform.GetComponent<Jugador>();
        animator = jugadorTransform.GetComponent<Animator>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (pj.GetMovH() == 0)
        {
            animator.SetTrigger("runEnd");
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("runEnd");
    }


}
