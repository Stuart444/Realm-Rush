using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    // OK to be public as this is a data class
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Waypoint exploredFrom;

    [SerializeField] Tower towerPrefab;

    Vector2Int gridPos;

    const int gridSize = 10;

    // Use this for initialization
    void Start () {
		
	}

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(gameObject.name + " Clicked");

            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Unable to place Tower");
            }
        }
    }
}
