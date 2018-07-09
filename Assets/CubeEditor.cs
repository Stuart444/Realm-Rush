using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update ()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();

        // Gets the first TextMesh it comes across in child objects
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = waypoint.GetGridPos().x / gridSize + "," 
            + waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText; // names the GameObject in the Hierarchy
    }
}
