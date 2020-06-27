using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DefenderInfo
{
    public Tower towerPrefab;
    public int towerCost;

    public int getMoveAmount()
    {
        return towerCost / 2;
    }
}
