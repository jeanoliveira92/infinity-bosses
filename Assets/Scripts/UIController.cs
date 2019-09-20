﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public AudioSource backgroundSound; 
    public GameObject IntroUI;
    public GameObject MainCanvas;
    public GameObject characterCanvas;
    public GameObject shadowUI;
    public GameObject sephirothUI;
    public GameObject thanosUI;
    private GameObject activeUI;
    private int charSelected = 1;

    IEnumerator WaitAndMainMenu()
    {
        yield return new WaitForSeconds(3.0f);
        backgroundSound.Play();
        GameObject parent = IntroUI.transform.parent.gameObject;
        MainCanvas.SetActive(true);
        parent.SetActive(false); 
    }
    IEnumerator WaitAndIntroUnifei()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject unifei = IntroUI.transform.GetChild(2).gameObject;
        unifei.SetActive(true);  
        StartCoroutine("WaitAndMainMenu");
    }
    IEnumerator WaitAndIntroUnity()
    {
        yield return new WaitForSeconds(2f);
        GameObject unity = IntroUI.transform.GetChild(1).gameObject;
        unity.SetActive(true);  
        StartCoroutine("WaitAndIntroUnifei");

    }
    void Start()
    {
        StartCoroutine("WaitAndIntroUnity");
        backgroundSound = GetComponent<AudioSource>();
        //backgroundSound.Play();
      
    }

    // Update is called once per frame
    void Update()
    {

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
    IEnumerator WaitToEnterScene()
    {
        yield return new WaitForSeconds(8.8f);
        SceneManager.LoadScene(1);
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
    public void StageSelect(){
        StartCoroutine("WaitToEnterScene");
        StartCoroutine("WaitToEnterAnimationScene");
        
        GameObject bg = activeUI.transform.GetChild(1).gameObject;
        GameObject label = activeUI.transform.GetChild(2).gameObject;
        GameObject texto = activeUI.transform.GetChild(3).gameObject;

        bg.SetActive(false);
        label.SetActive(false);
        texto.SetActive(false);
    }
}