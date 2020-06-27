using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesAlivePulbicShow;
    public float secondsBetweenSpawns = 3f;
    public static float countDown = 3f;
    public int waveSize;
    public static int rounds;
    public static int enemiesAlive = 0;
    public WaveInfo[] waveInfo;
    public static bool levelWon;
    public bool pirmasStartasBuvo;
    public bool kartaPraskaiciuotasLaikas = false;
    public static bool galimaPausint;

    void Start()
    {
        pirmasStartasBuvo = false;
        galimaPausint = true;
        levelWon = false;
        if (!pirmasStartasBuvo)
        {
            StartCoroutine(firstSpawn());
        }
    }

    private void Update()
    {
        if (waveSize == waveInfo.Length && enemiesAlive == 0)
        {
            levelWon = true;
            galimaPausint = false;
        }

        if (!pirmasStartasBuvo && enemiesAlive <= 0 )
        {
            countDown -= Time.deltaTime;
        }

        if (pirmasStartasBuvo)
        {
            if (enemiesAlive != 0)
            {
                return;
            }

            if (countDown <= 0)
            {
                countDown = secondsBetweenSpawns;
                StartCoroutine(RepeatedlySpawnEnemies());
            }

            if (!levelWon)
            {
                countDown -= Time.deltaTime;
            }
        }
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        WaveInfo wave = waveInfo[waveSize];
        for (int i = 0; i < wave.count; i++)
        {
            Instantiate(wave.enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            enemiesAlive++;
        }

        waveSize++;
        rounds++;
        pirmasStartasBuvo = true;
    }

    public float hu()
    {
        return countDown;
    }

    public bool isLevelWon()
    {
        return levelWon;
    }

    IEnumerator firstSpawn()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(RepeatedlySpawnEnemies());
        countDown = secondsBetweenSpawns;
    }
}
