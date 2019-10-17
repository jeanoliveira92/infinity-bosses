using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : Enemy {

   

    public float Force = 30f;


    public GameObject bullet;
    public Transform spawnPoint;
    
    private Animator anim;
     private Rigidbody2D rb;
    void Awake () {

        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
       
    }

    void update() {

        Instantiate (bullet, spawnPoint.position, spawnPoint.rotation);


    }

}