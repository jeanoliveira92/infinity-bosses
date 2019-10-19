﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public AudioSource backgroundSound; 
    public GameObject MainCanvas;
    public GameObject characterCanvas;
    public GameObject shadowUI;
    public GameObject sephirothUI;
    public GameObject thanosUI;
    private GameObject activeUI;
    public GameObject controlerUI;
    private int charSelected = 1;


    void Start()
    {
        
        MainCanvas.SetActive(true);
        //backgroundSound.Play();
      
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButtonDown (0) && controlerUI)
         //   attack ();
         Debug.Log(controlerUI.activeSelf);
    }
    IEnumerator WaitAndPLay()
    {
        yield return new WaitForSeconds(0.5f);
        characterCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        activeUI = shadowUI;
    }
    public void Play(GameObject obj){
        StartCoroutine("WaitAndPLay");
    }

    public void SelectCharacter(int id){
        
        charSelected = id;

        if(id == 1){
            shadowUI.SetActive(true);
            thanosUI.SetActive(false);
            sephirothUI.SetActive(false);
            activeUI = shadowUI;
        }else if(id == 2){
            thanosUI.SetActive(true);
            sephirothUI.SetActive(false);
            shadowUI.SetActive(false);
            activeUI = thanosUI;
        }else if(id == 3){
            sephirothUI.SetActive(true);
            thanosUI.SetActive(false);
            shadowUI.SetActive(false);
            activeUI = sephirothUI;
        }

    }
    IEnumerator WaitToEnterControlerScene()
    {
        yield return new WaitForSeconds(8.8f);
        characterCanvas.setActive(false);
        controlerUI.SetActive(true);
    }

    private void enterScene(){
        SceneManager.LoadScene(charSelected);
    }
    
    IEnumerator WaitToShowLogo()
    {
        yield return new WaitForSeconds(3.0f);
        
        GameObject logo = activeUI.transform.GetChild(5).gameObject;
        logo.SetActive(true);       
    }
    IEnumerator WaitToEnterAnimationScene()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("WaitToShowLogo");
        GameObject img = activeUI.transform.GetChild(4).gameObject;
        img.SetActive(true);  
    }

    public void ShowControlerUI(){

    }

    public void StageSelect(){
        StartCoroutine("WaitToEnterControlerScene");
        StartCoroutine("WaitToEnterAnimationScene");
        
        GameObject bg = activeUI.transform.GetChild(1).gameObject;
        GameObject label = activeUI.transform.GetChild(2).gameObject;
        GameObject texto = activeUI.transform.GetChild(3).gameObject;

        bg.SetActive(false);
        label.SetActive(false);
        texto.SetActive(false);
    }
}