using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float jumpForce = 300f;
  
    private Animator anim;

    public GameObject bridge;
    

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {   

     Physics2D.IgnoreCollision(bridge.GetComponent<Collider2D>(), GetComponent<Collider2D>());    
        
        StartCoroutine(Attack ());

    }

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(Random.Range(2, 4));
        jumpForce = Random.Range(250, 550);

        rb.AddForce(new Vector2(0, jumpForce));
        anim.SetBool("attack", true);

        yield return new WaitForSeconds(1.5f);
        anim.SetBool("attack", false);
        StartCoroutine(Attack ());

    }



}
