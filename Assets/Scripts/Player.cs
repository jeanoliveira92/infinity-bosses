using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    //Declaração de variáveis
    public GameObject player;

    //
    public AudioClip ringSound;
    public AudioClip heartSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;

    
    AudioSource audio;

    //Variavel que guarda a velocidade do personagem
    public float maxSpeed = 10;
    //força de pulo
    public float jumpForce = 450;
    public int life = 3;

    public int rings = 0;

    public bool gameOver = false;

    private Rigidbody2D rb;

    public Transform spawnPoint;

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

        audio = GetComponent<AudioSource>();

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


        Vector2 tela = Camera.main.WorldToScreenPoint(transform.position);
        if (tela.x < 0 || tela.y < 0 || tela.x > Screen.width || tela.y > Screen.height)
        {
            if (gameOver == false)
            {
                morrer();
            }


        }

    }

    void morrer()
    {

        //ação quando ele perde uma vida
        //vai ressurgir na tela no começo da fase
        //ou em checkpoint
        life--;
        if (life == 0)
        {

            //se era a ultima vida e deu gameover
            SceneManager.LoadScene(2);

        }
        else
        {

            respawn();
            audio.PlayOneShot(deathSound);
            anim.SetTrigger("respawn");

        }



    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        //pega o valor negativo, e faz o modulo
        anim.SetFloat("Velocidade", Mathf.Abs(h));
        

        rb.velocity = new Vector2(h * maxSpeed, rb.velocity.y);

      

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

            
            audio.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }

    public void respawn()
    {

        //arrumando a posição do personagem para voltar ao inicio
        player.transform.position = spawnPoint.transform.position;
        //--- feito isso para mudar a posição em z
        //pois p player estava voltando invisivel do spawn
        Vector3 novaPosicao = transform.position;
        novaPosicao.z = 2f;


        //passando a nova posição para o player.
        player.transform.position = novaPosicao;

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

    //verificar se esta passando pelas moedas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            morrer();

        }

        if (other.CompareTag("scoreRing"))
        {
            audio.PlayOneShot(ringSound);
            rings++;



            other.gameObject.SetActive(false);
            Destroy(other);
        }

        if (other.CompareTag("life"))
        {

            if (life < 3)
            {

                life++;
                audio.PlayOneShot(heartSound);
                other.gameObject.SetActive(false);
                Destroy(other);

            }
        }

    }

}

