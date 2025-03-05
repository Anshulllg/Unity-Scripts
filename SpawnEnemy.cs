using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public GameObject targetObject;
    public float minimumDistance = 5f; 
    public Vector2 xSpawnRange = new Vector2(-8, 9);
    public Vector2 zSpawnRange = new Vector2(-12, -2);
    public int maxEnemyCount = 20;
    public float spawnInterval = 2f;
    
    private int enemyCount = 0;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned! Please assign the object enemies should avoid.");
            return;
        }
        
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemyCount < maxEnemyCount)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
            enemyCount += 1;
        }
    }

    private Vector3 GetValidSpawnPosition()
    {
        Vector3 randomPosition;
        int attempts = 0;
        int maxAttempts = 30; // Prevent infinite loops
        
        do
        {
            float xPos = Random.Range(xSpawnRange.x, xSpawnRange.y);
            float zPos = Random.Range(zSpawnRange.x, zSpawnRange.y);
            randomPosition = new Vector3(xPos, 2, zPos);
            attempts++;
            
            // If we've tried too many times, just return the last position to avoid hanging
            if (attempts >= maxAttempts)
            {
                Debug.LogWarning("Could not find a valid spawn position after " + maxAttempts + " attempts. Consider reducing minimumDistance or expanding spawn area.");
                break;
            }
        } 
        while (Vector3.Distance(randomPosition, targetObject.transform.position) < minimumDistance);
        
        return randomPosition;
    }
}
