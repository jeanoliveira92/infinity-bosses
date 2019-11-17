using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlataformH : MonoBehaviour {

    public float moveSpeed;
    bool moveRight = true;

    public float menor, maior;

    public GameObject cam;
    public GameObject cam2;

    // Use this for initialization
    void Start () {

        Physics2D.IgnoreCollision (cam.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
        Physics2D.IgnoreCollision (cam2.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.x > maior)
            moveRight = false;
        if (transform.position.x < menor)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2 (transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }

}