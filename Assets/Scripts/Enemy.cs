using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    //inimigo leva dano do player
    private void takeDamage (int damage) {
        
        health -= damage;
        if (health <= 0) {
            Destroy (gameObject);
        }
    }

}