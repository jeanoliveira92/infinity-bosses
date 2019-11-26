using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsIdleBehaviour : StateMachineBehaviour
{
    private int sort;
    public float timer;
    public float minTime;
    public float maxTime;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       sort = Random.Range(1, 3);
       timer = Random.Range(minTime,maxTime);
        switch (sort)
        {
            case 1:
                animator.SetTrigger("Jump");
                break;

            case 2:
                animator.SetTrigger("shooting");
                break;
        }
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0){
            switch (sort)
            {
            case 1:
                animator.SetTrigger("Jump");
                break;

            case 2:
                animator.SetTrigger("shooting");
                break;
        }
        }
        else {
            timer -= Time.deltaTime;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
