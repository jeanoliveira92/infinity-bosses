using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishedController : MonoBehaviour
{
    public GameObject finished;
    public GameObject continued;
    public GameObject flag;
    int control = 0;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("piscaTxt");
    }

    IEnumerator piscaTxt()
    {
        yield return new WaitForSeconds(5.0f);
        flag.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        finished.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        continued.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && continued.activeInHierarchy)
        {
            StartCoroutine("enterScene");
        }
    }

        public void enterScene(){
        SceneManager.LoadScene("mainMenu");
    }
}
