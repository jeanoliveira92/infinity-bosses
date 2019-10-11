using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnuclesScript : Enemy
{   
    public float speed;
    public float followArea;
    private Transform target;
     private Animator anim;
     private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {   
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {   

        if(Vector2.Distance(transform.position, target.position) < followArea && Vector2.Distance(transform.position, target.position) > 1.3f){
           Vector2 targetPos = new Vector2(target.position.x, transform.position.y);
           transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
           anim.SetTrigger("run");
        }
    }
    
    private void takeDamage (int damage) {
        anim.SetTrigger("die");
        health -= damage;
        if (health <= 0) {
            Destroy (gameObject);
        }
    }
    
}
