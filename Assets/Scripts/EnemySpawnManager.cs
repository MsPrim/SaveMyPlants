using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private float spawnLimitUp = 14f;
    private float spawnLimitDown = -14f;
    private float spawnPosY = -16;

    private float startDelay = 2.0f;
    private float spawnInterval = 4.0f;

    public float sideSpawnX;
    public float sideSpawnMin;
    public float sideSpawnMax;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitUp, spawnLimitDown), spawnPosY, 0);
        Instantiate(enemyPrefabs[randomEnemyIndex], spawnPos, enemyPrefabs[0].transform.rotation);
        //spawnInterval += Random.Range(2.0f, 5.1f);
    }
    void SpawnRightEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, Random.Range(sideSpawnMin, sideSpawnMax), 0);
        Vector3 rotation = new Vector3(0, -180, 0);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.Euler(rotation));
        //spawnInterval += Random.Range(2.0f, 5.1f);
    }
    void SpawnLeftEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, Random.Range(sideSpawnMin, sideSpawnMax), 0);
        Vector3 rotation = new Vector3(0, 0, 0);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos,Quaternion.Euler(rotation));
        //spawnInterval += Random.Range(2.0f, 5.1f);
    }

    // Update is called once per frame
    void Update()
    {
        float timeNow = Time.realtimeSinceStartup;

        if (timeNow >= spawnInterval)
        {
            SpawnRandomEnemy();
            SpawnLeftEnemy();
            SpawnRightEnemy();
            spawnInterval += Random.Range(2.5f, 6f);
        }
    }
}
