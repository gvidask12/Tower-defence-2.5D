using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [SerializeField] Transform arrow;
    [SerializeField] Transform sword;
    [SerializeField] Transform magic;

    //[SerializeField] Transform enemy2;
    //[SerializeField] Transform enemy3;
    //[SerializeField] Transform enemy4;



    //[SerializeField] float attackRange = 10f;
    public float attackRange = 10f;

    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint;
    public int hitAmount;
    public int setAmount;

    public bool canAttack;

    void Update()
    {
        hitAmount = setAmount;
        SetTargetEnemy();
        if (targetEnemy)
        {

            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    public void SetTargetEnemy()
    {
        var sceneEnemy = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemy.Length == 0)
        {
            return;
        }

        Transform closestEnemy = sceneEnemy[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemy)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;

    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnemy()
    {
        var d = arrow.GetChild(2).gameObject.GetComponent<animationSwitch>();
        var dSword = sword.GetChild(1).gameObject.GetComponent<animationSwitchSword>();
        var dMagic = magic.GetChild(5).gameObject.GetComponent<animationSwitchMagic>();

        //var eEnemy2 = enemy2.GetChild(5).gameObject.GetComponent<switchAnimationEnemy1>();
        //var eEnemy3 = enemy3.GetChild(6).gameObject.GetComponent<switchAnimationEnemy2>();
        //var eEnemy4 = enemy4.GetChild(6).gameObject.GetComponent<switchAnimationEnemy3>();

        var e = targetEnemy.GetComponent<EnemyDamage>();

        float distanceToEnemey = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        
        //if (distanceToEnemey <= attackRange && EnemySpawner.enemiesAlive > 0)
        if (distanceToEnemey <= attackRange)
        {
            canAttack = true;
            e.getAmountToSub(hitAmount);
            d.getAttackActionCommand(canAttack);
            dSword.getAttackActionCommand(canAttack);
            dMagic.getAttackActionCommand(canAttack);

            Shoot(true);
        }

        else
        {
            canAttack = false;
            d.getAttackActionCommand(canAttack);
            dSword.getAttackActionCommand(canAttack);
            dMagic.getAttackActionCommand(canAttack);
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emmisionModule = projectileParticle.emission;
        emmisionModule.enabled = isActive;
    }

    public bool returncanAttack()
    {
        return canAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
