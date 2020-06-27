using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    Vector3 deathParticleVector;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem deathPart;
    public Image HealtBar;
    private float Health;
    public static int Deaths;
    public int amountOfHealthToSub;
    public bool playAnim;
    [SerializeField] AudioClip enemyDeathAudioClip;

    void Start()
    {
        Health = hitPoints;
    }

    private void Update()
    {
    }

    private void OnParticleCollision(GameObject other)
    {
        playAnim = true;
        //print("I'm hit");
        processHits();
        //print("Current hitpoints are " + hitPoints);
        if (hitPoints <= 0)
        {
            Deaths++;
            EnemySpawner.enemiesAlive--;
            hu();
            deathParticleVector = new Vector3(transform.position.x, 1f, transform.position.z);
            var deathVFX = Instantiate(deathPart, deathParticleVector, Quaternion.identity);
            deathVFX.Play();
            Destroy(deathVFX.gameObject, deathVFX.main.duration);
            Destroy(gameObject);
            PlayerStats.money += 10;
            AudioSource.PlayClipAtPoint(enemyDeathAudioClip, Camera.main.transform.position, 0.3f);
        }
        //playAnim = false;
    }


    public void processHits()
    {
        hitPoints -= setAmountToSub() ;
        HealtBar.fillAmount = hitPoints / Health;
        playAnim = true;
        StartCoroutine(Wait());
    }

    public void getAmountToSub(int amount)
    {
        amountOfHealthToSub = amount;
    }

    public int setAmountToSub()
    {
        return amountOfHealthToSub;
    }

    public float hu()
    {
        return Deaths;
    }

    /*public bool returnPlay()
    {
        return playAnimStatic;
    }*/

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.1f);
        playAnim = false;
    }
}
