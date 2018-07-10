﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startWayPoint, endWayPoint;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down,
                                Vector2Int.left, Vector2Int.right };

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColourStartAndEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int exploreCoordinates = startWayPoint.GetGridPos() + direction;

            if (grid.ContainsKey(exploreCoordinates))
            {
                grid[exploreCoordinates].SetTopColour(Color.yellow);
            }
        }
    }

    private void ColourStartAndEnd()
    {
        startWayPoint.SetTopColour(Color.green);
        endWayPoint.SetTopColour(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping Block detected: " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
