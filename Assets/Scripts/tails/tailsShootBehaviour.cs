using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsShootBehaviour : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public Transform firePoint;
    public GameObject specialBullet;

    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       firePoint = GameObject.FindGameObjectWithTag("Firepoint").GetComponent <Transform>();
       timer = Random.Range(minTime,maxTime);
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0){
            Instantiate(specialBullet, firePoint.position, firePoint.transform.rotation);
            animator.SetTrigger("Idle");
          
        }
        else {
            timer -= Time.deltaTime;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}