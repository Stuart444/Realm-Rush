using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int Score;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(SpawnEnemies());
        spawnedEnemies.text = Score.ToString();
	}

    IEnumerator SpawnEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(secondsBetweenSpawns);

        while(true)
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return delay;
        }
    }

    private void AddScore()
    {
        Score++;
        spawnedEnemies.text = Score.ToString();
    }
}
