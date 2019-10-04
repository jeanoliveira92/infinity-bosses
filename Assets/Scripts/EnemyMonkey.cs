using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonkey : Enemy

{

    public GameObject bullet;
    public Transform spawnPoint;
    
    

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        
           
              Instantiate (bullet, spawnPoint.position, spawnPoint.rotation);
           
        }

       
    }

   
}
