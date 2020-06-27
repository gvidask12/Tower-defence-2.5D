using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public static TowerFactory instance;
    //public Tower magicTowerPrefab;
    //public Tower swordTowerPrefab;
    //public Tower arrowTowerPrefab;

    [SerializeField] int towerLimit = 3;
    Queue<Tower> towerQueue = new Queue<Tower>();
    private DefenderInfo defenceToBuild;


    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Daugiau nei vienas instance");   
        }

        instance = this;
    }

    public void setDefenceToBuild(DefenderInfo defence)
    {
        defenceToBuild = defence;
    }


    public void AddTower(Waypoint baseWaypoint)
    {
        if (PlayerStats.money < defenceToBuild.towerCost)
        {
            return;
        }

        PlayerStats.money -= defenceToBuild.towerCost;
        
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;

        if (towerQueue.Count < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            PlayerStats.money += defenceToBuild.getMoveAmount();
            var oldTower = towerQueue.Dequeue();
            oldTower.baseWaypoint.isPlaceble = true;
            Destroy(oldTower.gameObject);
            oldTower.baseWaypoint = baseWaypoint;
            InstantiateNewTower(baseWaypoint);
        }
    }

    
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(defenceToBuild.towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceble = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceble = false;
        
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceble = true;
        newBaseWaypoint.isPlaceble = false;

        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
