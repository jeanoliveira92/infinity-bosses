using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //Declaração de variáveis

    public GameObject player;
    public AudioClip ringSound;
    public AudioClip heartSound;
    public AudioClip deathSound;
    public AudioClip jumpSound;
    private AudioSource audio;
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
    private bool dodge = false;
    //variavel usada para verificar se o personagem esta no "chao"
    public bool noChao = false;
    //Guarda a posição do objeto que detecta 
    //a colisão do personagem com o chao 
    //(como um objeto detector)
    public Transform groundCheck;
    //utilizados para o ataque corpo a corpo
    public float meleerange;
    public Transform meleePivot;
    public int meleeDamage;
    //utilizados para ataque especial
    public int especial = 0;

    public float dodgeForce;
    // Use this for initialization
    public bool DoubleJump = false;
    int numJump = 0;

    bool canDoubleJump = false;
    private bool startWalkAfterRespawn = true;
    private bool startWalking = true;

    public float spawnDelay = 1.2f;
    void Start () {

        audio = GetComponent<AudioSource> ();

        rb = gameObject.gameObject.GetComponent<Rigidbody2D> ();

        anim = gameObject.gameObject.GetComponent<Animator> ();

        //componente checa se o player esta tocando o chao
        groundCheck = gameObject.transform.Find ("Chao");

    }

    private void Update () {
        // ESTE IF BLOQUEIA O USUARIO DE MOVER ENQUANTO ESTIVER RESPAWNANDO
        if (startWalkAfterRespawn == true) {
            //variavel boleana checa a posição do groundCheck. Se ele estiver em um objeto na layer
            // "chao", ele fica verdadeiro
            noChao = Physics2D.Linecast (
                transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("chao")
            );

            //se for apertado o botao e se ele estiver no chao
            if (Input.GetButtonDown ("Jump") && noChao) {

                anim.SetTrigger ("Pulou");
                if (noChao) {

                    numJump = 0;
                }

                numJump++;
                jump = true;
                dodge = false;

            }

            if (Input.GetButtonDown ("Jump") && !noChao) {

                if (numJump == 1) {
                    DoubleJump = true;
                    anim.SetTrigger ("DoubleJump");
                } else {
                    DoubleJump = false;

                }

            }

            //esquiva

            if ((Input.GetKeyDown (KeyCode.J) || Input.GetKeyDown (KeyCode.E)) && (noChao)) {
                int i = 1;
                if (!facingRight) {
                    i = -i;
                }
                jump = false;
                dodge = true;
                anim.SetTrigger ("esquivou");
                rb.AddForce (new Vector2 (-dodgeForce * i, 150));
            }

            //Ataque corpo a corpo botão  "K"
            if (Input.GetKeyDown (KeyCode.K) || Input.GetMouseButtonDown (0))
                attack ();

            Vector2 tela = Camera.main.WorldToScreenPoint (transform.position);
            if (tela.x < 0 || tela.y < 0 || tela.x > Screen.width || tela.y > Screen.height) {
                morrer ();
            }

        }
    }

    void morrer () {

        //ação quando ele perde uma vida
        //vai ressurgir na tela no começo da fase
        //ou em checkpoint
        life--;
        if (life <= 0) {

            //se era a ultima vida e deu gameover

            Destroy (player);
            SceneManager.LoadScene ("gameOver");

        } else {
            respawn ();
            audio.PlayOneShot (deathSound);
            anim.SetTrigger ("respawn");

        }

    }

    private void attack () {
        //animação de ataque
        anim.SetTrigger ("attack");
        //verifica se existe algum collider dentro do raio de alcance e guarda em um vetor
        Collider2D[] results = Physics2D.OverlapCircleAll (meleePivot.position, meleerange);
        foreach (Collider2D c in results) {
            //se for um inimigo envia uma mensagem de dano
            if (c.gameObject.CompareTag ("Enemy")) {
                c.SendMessage ("takeDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void FixedUpdate () {
        float h = Input.GetAxisRaw ("Horizontal");

        if (startWalking == true && h == 0) {
            h = 0.4f;
        } else {
            startWalking = false;
        }

        //pega o valor negativo, e faz o modulo
        anim.SetFloat ("Velocidade", Mathf.Abs (h));

        rb.velocity = new Vector2 (h * maxSpeed, rb.velocity.y);

        if (h > 0 && !facingRight) {

            Flip ();

        } else if (h < 0 && facingRight) {

            Flip ();
        }

        if (jump) {

            audio.PlayOneShot (jumpSound);
            rb.AddForce (new Vector2 (0, jumpForce));
            jump = false;

        }

        if (DoubleJump && numJump == 1) {

            numJump = 0;
            rb.AddForce (new Vector2 (0, jumpForce - (jumpForce *0.30f)));
            DoubleJump = false;

        }

    }

    public void respawn () {

        //arrumando a posição do personagem para voltar ao inicio

        player.transform.position = spawnPoint.transform.position;
        Camera.main.transform.position = new Vector3 (spawnPoint.position.x, spawnPoint.position.y, -10);

        StartCoroutine ("WaitToRunAfterRespawn");

    }

    IEnumerator WaitToRunAfterRespawn () {
        yield return new WaitForSeconds (1.0f);
        startWalking = true;

    }

    void Flip () {
        //virando pra direita
        facingRight = !facingRight;

        //pega o valor da escala do player
        Vector3 theScale = transform.localScale;

        //inverte o valor da escala em x. 
        theScale.x *= -1;

        //atualiza valor da escala
        transform.localScale = theScale;

    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Enemy")) {
            morrer ();
        }

        //coleta de items

        if (other.CompareTag ("scoreRing")) {
            audio.PlayOneShot (ringSound);
            rings++;

            other.gameObject.SetActive (false);
            Destroy (other);
        }

        if (other.CompareTag ("life")) {

            if (life < 3) {

                life++;
                audio.PlayOneShot (heartSound);
                other.gameObject.SetActive (false);
                Destroy (other);

            }
        }

        if (other.CompareTag ("diamant")) {

            anim.SetTrigger ("diamant");
            other.gameObject.SetActive (false);
            Destroy (other);

        }

        if (other.CompareTag ("shoes")) {

            maxSpeed += (maxSpeed * 0.5f);
            other.gameObject.SetActive (false);
            Destroy (other);

        }

        if (other.CompareTag ("JumpPad")) {

            anim.SetTrigger ("Pulou");
            rb.AddForce (new Vector2 (0, jumpForce * 5));

        }

        if (other.CompareTag ("CheckPoint")) {

            spawnPoint.transform.position = other.transform.position;

        }

        if (other.CompareTag ("shield")) {
            other.gameObject.SetActive (false);
            Destroy (other);

        }

    }

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.name.Equals ("Plataform"))
            this.transform.parent = col.transform;

    }

    void OnCollisionExit2D (Collision2D col) {
        if (col.gameObject.name.Equals ("Plataform"))
            this.transform.parent = null;
    }

}