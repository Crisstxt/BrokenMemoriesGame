using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_dash_Behaviour : StateMachineBehaviour
{
    Transform Player;
    Jugador pj;
    float mov;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        pj = Player.GetComponent<Jugador>();
        mov = pj.GetMovH();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float am = pj.GetMovH();
        if(pj.GetOrientacion())
        {
            pj.SetMovH(mov * 2);
        } else
        {
            pj.SetMovH(mov * -2);
        }
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pj.SetMovH(mov);
    }


}
