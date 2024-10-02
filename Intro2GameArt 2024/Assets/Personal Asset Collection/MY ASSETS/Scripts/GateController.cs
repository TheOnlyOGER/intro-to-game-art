using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using HutongGames.PlayMaker;

public class GateController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] GameObject _button;
    PlayMakerFSM playMakerFSM, fsm;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        
        PlayMakerFSM[] temp = _button.GetComponents<PlayMakerFSM>();

        foreach (PlayMakerFSM fsm in temp)
        {
            if (fsm.FsmName == "button interaction")
            {
                playMakerFSM = fsm;
                break;
            }
        }

    }


    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player") && !playMakerFSM.FsmVariables.GetFsmBool("buttonOn").Value)
        {
            animator.SetTrigger("Gate controller");
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player") && !playMakerFSM.FsmVariables.GetFsmBool("buttonOn").Value) 
        {
            animator.SetTrigger("Gate controller");
        }
    }

}
