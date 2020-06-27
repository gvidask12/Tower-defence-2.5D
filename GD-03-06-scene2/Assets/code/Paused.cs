using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public Text rounds;
    public GameObject pausedUI;
    public GameObject mainCam;
    public GameObject gameOverCam;
    public GameObject menuDock;
    public EnemyDamage enemy;
    public GameObject clearPause;

    void Update()
    {
        rounds.text = "prevailing wave: " + EnemySpawner.rounds.ToString();


        if (PlayerStats.gameOver)
        {
            return;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && EnemySpawner.galimaPausint)
        {
            pausedActions();
        }
    }

    public void pausedActions()
    {
        pausedUI.SetActive(!pausedUI.activeSelf);
        mainCam.SetActive(mainCam.activeSelf);
        gameOverCam.SetActive(!gameOverCam.activeSelf);
        menuDock.SetActive(!menuDock.activeSelf);

        //if (pausedUI.activeSelf && mainCam.activeSelf && gameOverCam.activeSelf && !menuDock.activeSelf)
        if(pausedUI.activeSelf)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }


    }

    public void again()
    {
        pausedActions();
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(3);
        SceneManager.LoadScene(2);
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
