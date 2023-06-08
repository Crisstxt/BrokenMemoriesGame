using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : StateMachineBehaviour
{
    public Comportamiento cpt;
    public AtaqueController at;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cpt = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Comportamiento>();
        at = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AtaqueController>();
        cpt.mov = 0;
        cpt.isAttacking = true;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cpt.isAttacking = false;  
        at.obtenerNumero();
       
    }


}
