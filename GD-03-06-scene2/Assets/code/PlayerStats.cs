using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 100;
    public static int currentMoney;
    public int startHitPoints = 100;
    public static int baseHitPoints;
    public static bool gameOver = false;
    //public bool pirmasStartas = true;

    /*private void Update()
    {
            pirmasStartas = false;
        currentMoney = money;

        if (baseHitPoints <= 0)
        {
            gameOver = true;
        }
    }*/

    void Start()
    {
        baseHitPoints = startHitPoints;
        money = startMoney;
    }

    private void Update()
    {
        if(PlayerStats.gameOver)
            baseHitPoints = 60;
    }

    public int returnMoney()
    {
        return money;
    }
}
