using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlataformH : MonoBehaviour {

    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 2;
    public float Speed = 200;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;

    public bool _moveRight = true;

    public GameObject cam;
    public GameObject cam2;

    // Use this for initialization
    void Start () {

        Physics2D.IgnoreCollision (cam.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
        Physics2D.IgnoreCollision (cam2.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
    }

    public void Awake () {
        enemyRigidBody2D = GetComponent<Rigidbody2D> ();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
    }

    // Update is called once per frame
    public void Update () {

        if (!_moveRight) {
            enemyRigidBody2D.AddForce (Vector2.right * Speed * Time.deltaTime);
            
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = true;

        if (_moveRight) {
            enemyRigidBody2D.AddForce (-Vector2.right * Speed * Time.deltaTime);
           
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = false;

    }

}