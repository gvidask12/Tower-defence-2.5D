using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void levelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void levelMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void levelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void levelThree()
    {
        SceneManager.LoadScene(4);
    }
    public void quit()
    {
        Application.Quit();
    }

}
