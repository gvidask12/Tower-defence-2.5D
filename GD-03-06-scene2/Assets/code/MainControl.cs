using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainControl : MonoBehaviour
{
    EnemyMovement enemyMovement = new EnemyMovement();
    public GameObject gameOverUI;
    public GameObject levelWonUI;
    public GameObject mainCam;
    public GameObject gameOverCam;
    public GameObject menuDock;
    public bool gameOver;
    public SceneFadeIn sceneFadeIn;

    private void Start()
    {
        gameOver = false;
    }
    private void Update()
    {
        if (enemyMovement.hu() <= 0)
        {
            gameOver = true;
            EnemySpawner.galimaPausint = false;
            Invoke("gameOverActions", 1.5f);

        }
    }

    void gameOverActions()
    {
        gameOverUI.SetActive(true);
        mainCam.SetActive(false);
        gameOverCam.SetActive(true);
        menuDock.SetActive(false);
    }

    public void levelWon()
    {
        //Debug.Log();
        //sceneFadeIn.FadeTo(3);
    }
}
