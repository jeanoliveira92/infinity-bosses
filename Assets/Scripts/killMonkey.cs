using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMonkey : MonoBehaviour
{

     //vida do inimigo
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     //inimigo leva dano do player
    private void takeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
