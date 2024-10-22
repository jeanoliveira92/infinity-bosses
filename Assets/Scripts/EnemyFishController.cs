﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFishController : Enemy
{
    
    
    private Rigidbody2D rb;

    public float jumpForce = 300f;
  
    private Animator anim;


    //objeto da ponte
    public GameObject bridge;
    

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {   

        //pegando o colider da ponte, para o peixe poder atravesar, sem ter a colisão
     Physics2D.IgnoreCollision(bridge.GetComponent<Collider2D>(), GetComponent<Collider2D>());    
        
        StartCoroutine(Attack());

    }

    IEnumerator Attack()
    {
        //metodo que faz ele realizar ataques em um periodo de tempo aleatorio
        yield return new WaitForSeconds(Random.Range(2, 4));
        //força do pulo tambem pode variar, sendo aleatoria. 
        jumpForce = Random.Range(250, 550);

        //adiciona a força do pulo, para o peixe poder realizar o movimento
        rb.AddForce(new Vector2(0, jumpForce));
        //seta a animação de ataque do peixe
        anim.SetBool("attack", true);
        //espera um tempo para a animação acabar. 
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("attack", false);
        StartCoroutine(Attack ());

    }


}
