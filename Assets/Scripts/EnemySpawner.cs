using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(secondsBetweenSpawns);

        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return delay;
        }
    }
}
