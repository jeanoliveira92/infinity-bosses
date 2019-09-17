using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declaração de variáveis

    //Variavel que guarda a velocidade do personagem
    public float maxSpeed = 10;
    //força de pulo
    public float jumpForce = 450;

    private Rigidbody2D rb;

    //usado para ver se o personagem esta virado 
    //para a direita e inverter quando o personagem virar de lado
    public bool facingRight = true;

    private Animator anim;



    private bool jump = false;
    //variavel usada para verificar se o personagem esta no "chao"
    public bool noChao = false;


    //Guarda a posição do objeto que detecta 
    //a colisão do personagem com o chao 
    //(como um objeto detector)
    public Transform groundCheck;


   

    // Use this for initialization
    void Start()
    {

        rb = gameObject.gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.gameObject.GetComponent<Animator>();

        //componente checa se o player esta tocando o chao
        groundCheck = gameObject.transform.Find("Chao");
    }

    private void Update()
    {
        //variavel boleana checa a posição do groundCheck. Se ele estiver em um objeto na layer
        // "chao", ele fica verdadeiro
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << 
        LayerMask.NameToLayer("chao"));

        //se for apertado o botao e se ele estiver no chao
        if (Input.GetButtonDown("Jump") && noChao)
        {
            jump = true;
          anim.SetTrigger("Pulou");

        }

       
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        //pega o valor negativo, e faz o modulo
        anim.SetFloat("Velocidade", Mathf.Abs(h));

        rb.velocity = new Vector2(h * maxSpeed, rb.velocity.y);

        if(h > 7){

            anim.SetTrigger("rolou");
                   }

        if (h > 0 && !facingRight)
        {

            Flip();

        }
        else if (h < 0 && facingRight)
        {

            Flip();
        }

        if (jump)
        {

            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }

    void Flip()
    {
        //virando pra direita
        facingRight = !facingRight;

        //pega o valor da escala do player
        Vector3 theScale = transform.localScale;

        //inverte o valor da escala em x. 
        theScale.x *= -1;

        //atualiza valor da escala
        transform.localScale = theScale;

    }

}