using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    EnemyDamage damage = new EnemyDamage();
    EnemyMovement baseHitPoints = new EnemyMovement();
    EnemySpawner waveSpawn = new EnemySpawner();
    PlayerStats playerStats = new PlayerStats();

    public float money { get; private set; }
    public float bDamage { get; private set; }
    public float wave { get; private set; }

    public Text scoreEnemyDamage;
    public Text scoreBaseDamage;
    public Text waveIncoming;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerStats.money;
        //money = PlayerStats.money;
        scoreEnemyDamage.text = money.ToString();

        bDamage = PlayerStats.baseHitPoints;
        //bDamage = PlayerStats.baseHitPoints;
        scoreBaseDamage.text = bDamage.ToString();

        //wave = Mathf.Round((waveSpawn.hu() * 10f) * 0.1f);
        //waveIncoming.text = "WAVE INCOMING: " + wave.ToString();
        wave = Mathf.Clamp(waveSpawn.hu(), 0f, Mathf.Infinity);
        //wave = waveSpawn.hu();

        waveIncoming.text = string.Format("{0:0}", wave);
    }
}