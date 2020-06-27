using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWon : MonoBehaviour
{
    public GameObject levelWonUI;
    public GameObject mainCam;
    public GameObject gameOverCam;
    public GameObject menuDock;

    EnemySpawner enemy = new EnemySpawner();


    private void Update()
    {
        if (enemy.isLevelWon())
        { 
            //levelWon();
            Invoke("levelWon", 1.5f);
        }
    }

    public void levelWon()
    {
        levelWonUI.SetActive(true);
        mainCam.SetActive(false);
        gameOverCam.SetActive(true);
        menuDock.SetActive(false);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        SceneManager.LoadScene(0);
    }
}
