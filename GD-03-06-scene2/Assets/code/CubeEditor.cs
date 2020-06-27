using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    
    void Update()
    {
        SnapToGrid();
        //UpdateLabel();
    }

    private void SnapToGrid()
    {
        double gridSize = waypoint.GetGridSize();
        float variable = (float)gridSize;       //pakeitimas
        transform.position = new Vector3(waypoint.GetGridPos().x * variable, 0f, waypoint.GetGridPos().y * variable);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelName = textMesh.text = waypoint.GetGridPos().x + "-" + waypoint.GetGridPos().y;
        textMesh.text = labelName;
        gameObject.name = labelName;
    }
}
