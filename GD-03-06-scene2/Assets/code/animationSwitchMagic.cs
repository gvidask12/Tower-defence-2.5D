using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationSwitchMagic : MonoBehaviour
{
    public Animator anim;
    public Tower script;
    public bool attackAction;
    public bool pirmaMagija = false;
    [SerializeField] AudioClip arrowAudioClip;
    bool playedOnce = false;
    EnemySpawner enemySpawner = new EnemySpawner();

    void Start()
    {
        script = GameObject.Find("magija(Clone)").GetComponent<Tower>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (EnemySpawner.enemiesAlive > 0 && setAttackActionCommand() && enemySpawner.isLevelWon() == false)
        {
            anim.Play("Opening");
            if (!playedOnce)
            {
                AudioSource.PlayClipAtPoint(arrowAudioClip, Camera.main.transform.position, 0.3f);
                playedOnce = true;
                StartCoroutine(waitForSound());
            }
        }

        //else if (!setAttackActionCommand())
        else
        { 
               anim.Play("Breathing Idle"); 
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
