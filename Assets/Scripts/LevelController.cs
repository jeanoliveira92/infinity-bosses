using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public camera cam;

    public GameObject pauseUI;

    public Transform c;

    public static LevelController lc;

    public Player shadow;

    public TextMeshProUGUI life;
    public TextMeshProUGUI ring;
    // Start is called before the first frame update

    void Start () {
        if (lc == null) {
            lc = GameObject.FindGameObjectWithTag ("LevelController").GetComponent<LevelController> ();

        }
    }
    public Transform player;
    public Transform spawnPoint;

    public float spawnDelay = 1.2f;

    public IEnumerator RespawnPlayer () {

        yield return new WaitForSeconds (spawnDelay);
        Instantiate (player, spawnPoint.position, spawnPoint.rotation);

    }

    public void KillPlayer () {
        Destroy (player.gameObject);
        lc.StartCoroutine (lc.RespawnPlayer ());

    }
    // Update is called once per frame
    void Update () {
        

        life.SetText (shadow.life.ToString ());
        ring.SetText (shadow.rings.ToString ());

        if (Input.GetKeyDown (KeyCode.Escape)) {
            pauseGame ();
           
        }

        if (shadow.life == 0) {

            SceneManager.LoadScene ("gameOver");

        }

    }

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

    bool isPaused = false;
    public void pauseGame () {

        if (isPaused) {

            Time.timeScale = 1;
            isPaused = false;
            pauseUI.SetActive (false);
        } else {

            Time.timeScale = 0;
            isPaused = true;
            pauseUI.SetActive (true);
        }

    }

}