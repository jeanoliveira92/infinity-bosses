using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscamera : MonoBehaviour
{   

    public GameObject cameraStop;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            cameraStop.SendMessage("stop",0,SendMessageOptions.DontRequireReceiver);
            Boss.SetActive(true);
            
        }
    }
}
