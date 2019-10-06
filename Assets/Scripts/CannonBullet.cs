using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
     private Rigidbody2D rb;

     public float force = -200;
    void Awake () {

        rb = GetComponent<Rigidbody2D> ();
       
    }


    void update(){

         
    }

}