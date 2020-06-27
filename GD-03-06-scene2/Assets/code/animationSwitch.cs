using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSwitch : MonoBehaviour
{
    public Animator anim;
    public Tower script;
    public bool attackAction;
    [SerializeField] AudioClip arrowAudioClip;
    bool playedOnce = false;
    EnemySpawner enemySpawner = new EnemySpawner();

    void Start()
    {
        script = GameObject.Find("Defence(Clone)").GetComponent<Tower>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(EnemySpawner.enemiesAlive > 0 && setAttackActionCommand() && enemySpawner.isLevelWon() == false)
        {
            anim.Play("Shooting Arrow");
            if (!playedOnce)
            {
                AudioSource.PlayClipAtPoint(arrowAudioClip, Camera.main.transform.position, 0.5f);
                playedOnce = true;
                StartCoroutine(waitForSound());
            }
        }

        //else if(!setAttackActionCommand())
        else
        { 
            anim.Play("Shooting-Idle Arrow"); 
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
        yield return new WaitForSeconds(4.3f);
        playedOnce = false;
    }
}
