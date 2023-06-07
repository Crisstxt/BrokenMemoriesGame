using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SD_Shield : StateMachineBehaviour
{
    public AtaqueController at;
    public Comportamiento cpt;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        at = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AtaqueController>();
        cpt = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Comportamiento>();
        cpt.mov = 0;
        cpt.isAttacking = true;
        at.shieldUp = true;

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        at.shieldUp = false;
        cpt.mov = cpt.velocidadMov;
        cpt.isAttacking = false;
    }


}
