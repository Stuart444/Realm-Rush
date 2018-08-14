using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        print("I'm Hit");
        
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--;
        print("Current HP: " + hitPoints);
    }
}
