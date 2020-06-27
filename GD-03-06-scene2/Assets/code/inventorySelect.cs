using System.Collections.Generic;
using UnityEngine;

public class inventorySelect : MonoBehaviour
{
    public DefenderInfo magicTowerPrefab;
    public DefenderInfo swordTowerPrefab;
    public DefenderInfo arrowTowerPrefab;

    TowerFactory towerFactory;
    public void Start()
    {
        towerFactory = TowerFactory.instance;
    }

    public void magicDefence()
    {
        Debug.Log("MAGIJA");
        towerFactory.setDefenceToBuild(magicTowerPrefab);
    }

    public void swordDefence()
    {
        Debug.Log("KARDAS");
        towerFactory.setDefenceToBuild(swordTowerPrefab);

    }

    public void arrowDefence()
    {
        Debug.Log("LANKAS");
        towerFactory.setDefenceToBuild(arrowTowerPrefab);

    }
}
