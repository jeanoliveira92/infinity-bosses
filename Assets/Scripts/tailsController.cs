using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsController : Enemy
{

    public Transform firePoint;
    public GameObject specialBullet;


    private Animator anim;
    private Rigidbody2D rb;

    bool attacking;
    int sort = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.gameObject.GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine("attacks");
    }
    private void sorteio()
    {
        //Escolhe um número de 1 a 4
        sort = Random.Range(1, 4);
    }

    IEnumerator attacks()
    {
        if (attacking)
            yield break;

        attacking = true;
        yield return new WaitForSeconds(1.8f);
        sorteio();
        switch (sort)
        {
            case 1:
                jump();
                break;

            case 2:
                StartCoroutine("specialAttack");
                break;

            case 3:
                jump();
                break;
        }
        attacking = false;

    }
    IEnumerator specialAttack()
    {
        
        //animação de preparo
        anim.SetTrigger("shooting");
        yield return new WaitForSeconds(0.7f);
        //animação de ataque
        anim.SetTrigger("shoot");
        //logica de disparo
        Instantiate(specialBullet, firePoint.position, firePoint.rotation);
        
    }

    

    private void jump()
    {
        
        //Animação de pular
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(200, 400));
        
    }
}