using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

       private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
           anim = gameObject.gameObject.GetComponent<Animator> ();
    }

    private void OnTriggerEnter2D (Collider2D other) {
       

         if (other.CompareTag ("Player")) {

             anim.SetTrigger("CheckPoint");

        }


    }
}
