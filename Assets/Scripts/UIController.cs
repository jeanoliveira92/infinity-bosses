using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public GameObject MainCanvas;
    public GameObject characterCanvas;
    public GameObject shadowUI;
    public GameObject sephirothUI;
    public GameObject thanosUI;
    private GameObject activeUI;
    public GameObject controlerUI;
    private int charSelected = 1 ;
    void Update()
    {
        // SE A O UI CONTROLER ESTIVER ATIVO
       if (controlerUI.activeInHierarchy){
           // SE O TEXT DE CONTINUE ESTIVER ATIVO
            if(controlerUI.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.transform.GetChild(2)
                .gameObject.activeInHierarchy){
                    // SE CLICAR COM O BOTÃO DIREITO DO MOUSE
                    if (Input.GetMouseButtonDown(0)){
                        StartCoroutine("WaitAndEnterScene");
                    }
                } 
        }
    }

    /*  ---------------------- START MENU ---------------------- */
    void Start(){
        MainCanvas.SetActive(true);
    }   

    public void quit(){
        Application.Quit();
    } 

    IEnumerator WaitAndPLay(){
        yield return new WaitForSeconds(0.5f);
        characterCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        activeUI = shadowUI;
    }
    public void Play(GameObject obj){
        StartCoroutine("WaitAndPLay");
    }

    /*  ---------------------- MENU SELEÇÃO PERSONAGEM ---------------------- */
    public void SelectCharacter(int id){
        charSelected = id;
        activeUI.SetActive(false);
        if(id == 1){
            shadowUI.SetActive(true);
            activeUI = shadowUI;
        }else if(id == 2){
            thanosUI.SetActive(true);
            activeUI = thanosUI;
        }else if(id == 3){
            sephirothUI.SetActive(true);
            activeUI = sephirothUI;
        }
    }
    public void StageSelect(){
        StartCoroutine("StageSelectIE");
        
        activeUI.transform.GetChild(1).gameObject.SetActive(false);
        activeUI.transform.GetChild(2).gameObject.SetActive(false);
        activeUI.transform.GetChild(3).gameObject.SetActive(false);
    }
    IEnumerator StageSelectIE()
    {
        // APARECER A ANIMAÇÃO DO PERSONAGEM
        yield return new WaitForSeconds(3.0f);
        activeUI.transform.GetChild(4).gameObject.SetActive(true);
        
        // APARECER A ANIMAÇÃO DO  NOME DO PERSONAGEM
        yield return new WaitForSeconds(3.0f);
        activeUI.transform.GetChild(5).gameObject.SetActive(true);
        
        // IR PARA A EXIBIÇÃO DOS CONTROLES 
        yield return new WaitForSeconds(3.0f);
        characterCanvas.SetActive(false);
        controlerUI.SetActive(true);

        // EXIBIR A TELA DE CONTROLE
        yield return new WaitForSeconds(5.0f);
        controlerUI.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.transform.GetChild(2)
                .gameObject.SetActive(true);
    }

    IEnumerator WaitAndEnterScene(){
        
        controlerUI.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.GetComponent<Animator>().SetBool("end", true);

        controlerUI.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.transform.GetChild(1)
                .gameObject.GetComponent<Animator>().SetBool("end", true);

        controlerUI.transform.GetChild(0)
                .gameObject.transform.GetChild(0)
                .gameObject.transform.GetChild(2)
                .gameObject.GetComponent<Animator>().SetBool("end", true);

        yield return new WaitForSeconds(2.0f);
        enterScene();
    }

    public void enterScene(){
        SceneManager.LoadScene(charSelected);
    }
}