using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawnManager : MonoBehaviour
{
    public bool isGameActive = false;
    private Destroy destroy;
    public TextMeshProUGUI gameOverText;

    public GameObject[] enemyPrefabs;

    private float spawnLimitUp = 14f;
    private float spawnLimitDown = -14f;
    private float spawnPosY = -16;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    private float rightEnemySpawnInterval = 4.5f;
    private float leftEnemySpawnInterval = 5.0f;

    public float sideSpawnX;
    public float sideSpawnMin;
    public float sideSpawnMax;
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            isGameActive = true;

            if (isGameActive)
            {
                InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
                InvokeRepeating("SpawnRightEnemy", startDelay, rightEnemySpawnInterval);
                InvokeRepeating("SpawnLeftEnemy", startDelay, leftEnemySpawnInterval);
            }
        }
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
        Vector3 rotation = new Vector3(0, 0, 0);
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
        if(isGameActive)
        {
           // float timeNow = Time.realtimeSinceStartup;
           //
           // if (timeNow >= spawnInterval)
           // {
           //     SpawnRandomEnemy();
           //     SpawnLeftEnemy();
           //     SpawnRightEnemy();
           //     spawnInterval += Random.Range(2.5f, 6f);
           // }
        }
    }
    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        CancelInvoke();
        isGameActive = false;
        SceneManager.LoadScene("YouLoseScene");
    }
}
