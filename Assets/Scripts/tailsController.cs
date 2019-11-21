using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailsController : Enemy {

    public Transform firePoint;
    public GameObject specialBullet;

    public float speed;
    public float followArea;
    private Transform target;


    private Animator anim;
    private Rigidbody2D rb;

    bool attacking = false;
    int sort = 0;

    // Start is called before the first frame update
    void Start () {
        rb = gameObject.gameObject.GetComponent<Rigidbody2D> ();

        anim = gameObject.gameObject.GetComponent<Animator> ();
        
        target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update () {
        //Se não estiver atacando o "sorteio é realizado"
        if (!attacking) {
            sorteio();
            switch(sort){
                case 0:
                punch();
                break;

                case 1:
                jump();
                break;

                case 2:
                StartCoroutine("spinAttack");
                break;

                case 3:
                StartCoroutine ("specialAttack");
                break;
            }
        }
    }
    private void sorteio(){
        //Escolhe um número de 0 a 3
        sort = Random.Range(0,4);        
    }

    IEnumerator specialAttack () {
        attacking = true;
        //animação de preparo
        anim.SetTrigger ("shooting");
        yield return new WaitForSeconds(0.7f);
        //animação de ataque
        anim.SetTrigger ("shoot");
        //logica de disparo
        Instantiate (specialBullet, firePoint.position, firePoint.rotation);
        attacking = false;
    }

    IEnumerator spinAttack (){
        //pula antes de atacar
        jump();
        yield return new WaitForSeconds(0.2f);
        //animação de ataque
        anim.SetTrigger ("Spin");
        rb.AddForce(new Vector2(300, 50));
        attacking = false;
    }

    private void punch (){
        attacking = true;
        //vai em direção ao player até estar perto o suficiente

        while( Vector2.Distance (transform.position, target.position) > 1f) {
                Vector2 targetPos = new Vector2 (target.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
                anim.SetTrigger ("run");
        }
        //ataca quando estiver perto
        anim.SetTrigger("Punch");
        rb.AddForce(new Vector2(100, 0));
        attacking = false;
    }

    private void jump(){
        attacking = true;
        //Animação de pular
        anim.SetTrigger("Jump");
        rb.AddForce(new Vector2(0, 300));
        attacking = false;
    }
}