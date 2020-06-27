using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSwitchSword : MonoBehaviour
{
    public Animator anim;
    public Tower script;
    public bool attackAction;

    [SerializeField] AudioClip arrowAudioClip;
    bool playedOnce = false;
    bool animDonePlaying;

    EnemySpawner enemySpawner = new EnemySpawner();

    void Start()
    {
        script = GameObject.Find("kardas(Clone)").GetComponent<Tower>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (EnemySpawner.enemiesAlive > 0 && setAttackActionCommand() && enemySpawner.isLevelWon() == false)
        {
            anim.Play("Take 001");

            if (!playedOnce)
            {
                AudioSource.PlayClipAtPoint(arrowAudioClip, Camera.main.transform.position,0.2f);
                playedOnce = true;
                StartCoroutine(waitForSound());
            }
        }

        //else if(setAttackActionCommand() == false)
        else
        { 
            anim.Play("Take 001 0"); 
        }
    }

    public void getAttackActionCommand(bool attack)
    {
        attackAction = attack;
    }

    public bool setAttackActionCommand()
    {
        return attackAction;
    }
    IEnumerator waitForSound()
    {
        yield return new WaitForSeconds(2.6f);
        playedOnce = false;
    }
}
