using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataformV : MonoBehaviour
{ 
    public float moveSpeed = 3f;
    bool moveUp = true;

    public float pointOne, pointTwo;

    public GameObject cam;
    public GameObject cam2;

    // Use this for initialization
    void Start () {

        Physics2D.IgnoreCollision (cam.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
        Physics2D.IgnoreCollision (cam2.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y > pointTwo)
            moveUp = false;
        if (transform.position.y < pointOne)
            moveUp = true;

        if (moveUp)
            transform.position = new Vector2 (transform.position.x , transform.position.y + moveSpeed * Time.deltaTime);
        else
            transform.position = new Vector2 (transform.position.x , transform.position.y-  moveSpeed * Time.deltaTime);
    }

}
