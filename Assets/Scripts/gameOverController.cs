using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour {

    public void restart () {

        SceneManager.LoadScene ("shadow");

    }

    public void backToMenu () {

        SceneManager.LoadScene ("mainMenu");

    }

}