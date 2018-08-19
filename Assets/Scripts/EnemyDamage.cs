using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemydeathSFX;

    AudioSource myAudioSource;

	// Use this for initialization
	void Start () {

        myAudioSource = GetComponent<AudioSource>();
		
	}

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;

        Destroy(vfx.gameObject, destroyDelay);
        AudioSource.PlayClipAtPoint(enemydeathSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }
}
