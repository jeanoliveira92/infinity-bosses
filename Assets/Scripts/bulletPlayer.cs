using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour

{
    // Start is called before the first frame update

    public float speed = 20f;
    public Rigidbody2D rb;

    private Animator anim;

    public int damage;

    void Start () {

        rb.velocity = transform.right * speed;
        anim = gameObject.gameObject.GetComponent<Animator> ();

    }

    void OnTriggerEnter2D (Collider2D hitInfo) {

       
        Enemy enemy = hitInfo.GetComponent<Enemy> ();
        if (enemy != null) {

            enemy.takeDamage (damage);
        }
       
        Destroy (gameObject);

    }

    void OnCollisionEnter2D (Collision2D col) {
        if (!col.gameObject.name.Equals ("Player")) {
           
            Destroy (gameObject);
        }

    }


}