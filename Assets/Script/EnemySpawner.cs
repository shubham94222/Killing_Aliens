using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 3.0f;
    public float spawnRange = 10.0f;

    private float lastSpawnTime = 0.0f;

    private void Update()
    {
        if (Time.time - lastSpawnTime > spawnDelay)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRange;
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        EnemyController enemyMovement = enemy.GetComponent<EnemyController>();
        if (enemyMovement != null)
        {
            enemyMovement.target = GameObject.FindWithTag("Player").transform;
        }
    }
}

