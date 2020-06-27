using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    Tower tower = new Tower();

    void Update()
    {
        if (tower.returncanAttack() == true)
        {
            //audioSource.Play();
        }
    }
}
