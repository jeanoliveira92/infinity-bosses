using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{

    public GameObject IntroUI;
    private int charSelected = 1;
    IEnumerator WaitToEnterScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }
    IEnumerator WaitAndIntroUnifei()
    {
        yield return new WaitForSeconds(3.0f);
        GameObject unifei = IntroUI.transform.GetChild(2).gameObject;
        unifei.SetActive(true);  
        StartCoroutine("WaitToEnterScene");
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
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}