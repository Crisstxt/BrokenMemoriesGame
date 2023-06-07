using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_Awake : StateMachineBehaviour
{
    private Comportamiento cpt;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cpt = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Comportamiento>();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cpt.isActivated = true;
    }

}
