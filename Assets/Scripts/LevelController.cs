using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public camera cam;
    public Transform c;
    public Player shadow;
    public TextMeshProUGUI life;
    public TextMeshProUGUI ring;
    public GameObject UIPause;

    // Start is called before the first frame update
    void Start () {
      
    }

    public Transform player;

    // Update is called once per frame
    void Update () {

       

        life.SetText (shadow.life.ToString ());
        ring.SetText (shadow.rings.ToString ());

        if (Input.GetKeyDown (KeyCode.Escape)) {
            pauseGame ();

        }

    }

    public void backToMenu () {

        SceneManager.LoadScene ("mainMenu");

    }

    public void restartScene () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
        Time.timeScale = 1;
    }

    private bool isPaused = false;
    public void pauseGame () {
        if (isPaused) {
            Time.timeScale = 1; 
            isPaused = false;
            UIPause.SetActive (false);
            
        } else {
            Time.timeScale = 0;
            isPaused = true;
            UIPause.SetActive (true);
            
        }

    }

    public void enableControlersScreen () {
        UIPause.transform.GetChild (5).gameObject.SetActive (true);
    }
    public void DisableControlersScreen () {
        UIPause.transform.GetChild (5).gameObject.SetActive (false);
    }

}