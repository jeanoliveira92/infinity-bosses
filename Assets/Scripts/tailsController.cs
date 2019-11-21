using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsController : MonoBehaviour {

    public Transform firePoint;
    public GameObject specialBullet;

    private Animator anim;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start () {
        rb = gameObject.gameObject.GetComponent<Rigidbody2D> ();

        anim = gameObject.gameObject.GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update () {

    }

    private void specialAttack () {
        //animação de ataque
        anim.SetTrigger ("shoot");
        //logica de disparo
        Instantiate (specialBullet, firePoint.position, firePoint.rotation);

    }
}