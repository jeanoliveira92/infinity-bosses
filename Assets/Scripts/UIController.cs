using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(){
        SceneManager.LoadScene(1);
       
    }
}