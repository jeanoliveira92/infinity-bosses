using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsBullet : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;

    private Animator anim;

    public int damage;
    public GameObject impactEffect;

    void Start () {

        Physics2D.IgnoreLayerCollision (12, 13);
        Physics2D.IgnoreLayerCollision (12, 15);
        rb.velocity = transform.right * speed;
        anim = gameObject.gameObject.GetComponent<Animator> ();

    }


    void OnCollisionEnter2D (Collision2D col) {
        if (!col.gameObject.name.Equals ("Enemy")) {

            gameObject.SetActive (false);
            Destroy (gameObject);
        }

    }
}