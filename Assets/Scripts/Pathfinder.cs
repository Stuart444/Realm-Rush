using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] Waypoint startWayPoint, endWayPoint;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right,
                                Vector2Int.down, Vector2Int.left };

    bool isRunning = true;
    Waypoint searchCenter; // the current searchCenter
    public List<Waypoint> path = new List<Waypoint>(); // TODO: Make Private

    public List<Waypoint> GetPath()
    {
        // If there is no path, it calculates the path
        // and stores (Caches) it. If there is a path,
        // it returns the already available path.
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColourStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        path.Add(endWayPoint);

        Waypoint previous = endWayPoint.exploredFrom;

        while (previous != startWayPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWayPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            EndNodeFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void EndNodeFound()
    {
        if (searchCenter == endWayPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;

            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            // Do Nothing
        }
        else
        {
            neighbour.SetTopColour(Color.yellow);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
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
