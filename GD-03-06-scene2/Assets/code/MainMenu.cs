using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("play");
    }

    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
