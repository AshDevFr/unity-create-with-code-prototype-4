using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange = 9.0f;
    public float spawnPowerupRange = 5.0f;

    private int spawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave();
        }
    }

    void SpawnEnemyWave()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, SpawnPosition(spawnRange), Quaternion.identity);
        }

        Instantiate(powerupPrefab, SpawnPosition(spawnPowerupRange), Quaternion.identity);

        spawnCount++;
    }

    Vector3 SpawnPosition(float range)
    {
        float spawnX = Random.Range(-range, range);
        float spawnZ = Random.Range(-range, range);
        return new Vector3(spawnX, 0, spawnZ);
    }
}