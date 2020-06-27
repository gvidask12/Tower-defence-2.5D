using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //PathFinder pathFinder = new PathFinder();
    [SerializeField] Transform targetGoal;
    [SerializeField] Transform objectToPan;
    Vector3 goalParticleVector;
    [SerializeField] ParticleSystem goalParticles;
    //public int startHitPoints = 30;
    //public static int baseHitPoints;
    public float enemyMoveSpeed = 1.0f;
    [SerializeField] AudioClip enemyGoalAudioClip;

    void Start()
    {
        //baseHitPoints = startHealth;
        //gameOverUI = GameObject.Find("GameOverUI");
        //StartCoroutine(FollowPath());
        //print("Back at Start");
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private void Update()
    {
        
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in path)
        {
            objectToPan.LookAt(targetGoal);
            transform.position = waypoint.transform.position;
            //print("Visiting block" + transform.position);
            yield return new WaitForSeconds(enemyMoveSpeed);
        }
        goalParticleVector = new Vector3(transform.position.x, 1.9f, transform.position.z);
        var goalVFX = Instantiate(goalParticles, goalParticleVector, Quaternion.identity);
        goalVFX.Play();
        AudioSource.PlayClipAtPoint(enemyGoalAudioClip, Camera.main.transform.position, 0.3f);
        Destroy(goalVFX.gameObject, goalVFX.main.duration);
        Destroy(gameObject);
        print("Ending patrol");
        PlayerStats.baseHitPoints -= 10;
        EnemySpawner.enemiesAlive--;
    }

    public float hu()
    {
        return PlayerStats.baseHitPoints;
    }
}
