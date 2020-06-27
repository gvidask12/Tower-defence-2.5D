using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool isPlaceble = true;


    Vector2 gridPos;
    const double gridSize = 2.63;
    public double GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        float variable = (float)gridSize;   //pakeitimas
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / variable),
            Mathf.RoundToInt(transform.position.z / variable)
        );
    }

    private void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceble)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            //else { print("Can't place tower on: " + gameObject.name); }
        }
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (isPlaceble)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
