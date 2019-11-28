using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsDiedBehaviour : StateMachineBehaviour
{
    public float timer;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0){
            
            //SceneManager.LoadScene ("winner");
          
        }
        else {
            timer -= Time.deltaTime;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}