using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverController : MonoBehaviour
{

    public GameObject Buttons1;
    public GameObject Buttons2;
    public GameObject loading;
    private AudioSource audioSource;
    public Sprite shadow, sephiroth, thanos;

    private void restartShadow()
    {
        StartCoroutine("WaitAndloadScene");
    }

    private void restartThanos()
    {
        loading.GetComponent<Image>().sprite  = thanos;
        loading.SetActive(true);
        SceneManager.LoadScene("Thanos");

    }

    private void restartSephiroth()
    {

        loading.GetComponent<Image>().sprite = shadow;
        loading.SetActive(true);
        SceneManager.LoadScene("Sephiroth");

    }

    
    IEnumerator WaitAndloadScene()
    {
        loading.GetComponent<Image>().sprite = shadow;
        loading.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Shadow");
    }

    public void backToMenu()
    {

        SceneManager.LoadScene("mainMenu");

    }

    void Awake()
    {   StartCoroutine("WaitShowButtons");
        StartCoroutine("WaitAndPlayBGSound");
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator WaitAndPlayBGSound()
    {
        yield return new WaitForSeconds(2.5f);
        audioSource.Play();
    }
    IEnumerator WaitShowButtons()
    {
        yield return new WaitForSeconds(11.0f);
        Buttons1.SetActive(true);
        Buttons2.SetActive(true);

    }

}