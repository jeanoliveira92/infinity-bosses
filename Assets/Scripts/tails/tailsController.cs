using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsController : MonoBehaviour
{
    private Animator anim;
    public int health;


    // Start is called before the first frame update
    void Start()
    {

        anim = gameObject.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage (int damage) {

        health -= damage;
        if (health <= 0) {
            anim.SetTrigger("died");
        }
        
    }
    
}