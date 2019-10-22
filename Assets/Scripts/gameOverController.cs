using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour {
    private string restartScene = "mainmenu";
    public void restartShadow () {
        SceneManager.LoadScene ("Shadow");
    }

     public void restartThanos () {
        SceneManager.LoadScene ("Thanos");
    }

     public void restartSephiroth () {
        SceneManager.LoadScene ("Sephiroth");
    }

    public void backToMenu () {
        SceneManager.LoadScene ("mainMenu");
    }

    public void restart(){
        SceneManager.LoadScene(restartScene);
    }

}