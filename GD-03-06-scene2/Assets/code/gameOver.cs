using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    EnemyDamage enemy;
    public Text rounds;
    MainControl control = new MainControl();
    void OnEnable()
    {
        rounds.text = "waves survived: " + EnemySpawner.rounds.ToString();
    }

    public void again()
    {
        Debug.Log("again");
        SceneManager.LoadScene(2);
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
