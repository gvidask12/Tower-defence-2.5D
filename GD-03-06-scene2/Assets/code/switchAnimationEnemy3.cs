using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAnimationEnemy3 : MonoBehaviour
{
    public Animator anim;
    Tower tower = new Tower();
    [SerializeField] AudioClip swordDefenderAudioClip;
    bool playedOnce = false;
    public EnemyDamage script;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        script = GameObject.Find("Enemy 3(Clone)").GetComponent<EnemyDamage>();
        if (script.playAnim)
        //if(Input.GetKey("1"))
        {
            anim.Play("Take 001");

            /*if (!playedOnce)
            {
                AudioSource.PlayClipAtPoint(swordDefenderAudioClip, Camera.main.transform.position);
                playedOnce = true;
                StartCoroutine(Wait());
            }*/
        }
        //if(Input.GetKey("2"))
        else if (script.playAnim == false)
        {
            anim.Play("Take 001");
        }
    }

    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.5f);
        playedOnce = false;
    }*/
}
