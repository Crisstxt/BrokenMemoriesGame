using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hit_behaviour : StateMachineBehaviour
{
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<JugadorCombateController>().TerminarCombo();
    }


}
