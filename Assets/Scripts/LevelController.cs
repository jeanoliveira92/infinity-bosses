﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{

    public static LevelController lc;

    public Player shadow;

    public TextMeshProUGUI life;
    public TextMeshProUGUI ring;
    // Start is called before the first frame update

    void Start()
    {
        if (lc == null)
        {
            lc = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();

        }
    }
    public Transform player;
    public Transform spawnPoint;

    public float spawnDelay = 1.2f;

    
 public IEnumerator RespawnPlayer()
{

    yield return new WaitForSeconds(spawnDelay);
    Instantiate(player, spawnPoint.position, spawnPoint.rotation);

}

public void KillPlayer()
{
     Destroy(player.gameObject);
    lc.StartCoroutine(lc.RespawnPlayer());

}
// Update is called once per frame
void Update()
{

    life.SetText(shadow.life.ToString());
    ring.SetText(shadow.rings.ToString());

}

}




