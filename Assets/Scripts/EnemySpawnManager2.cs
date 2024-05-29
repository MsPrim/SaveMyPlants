using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnManager2 : MonoBehaviour
{
    public bool isGameActive = false;
    //public TextMeshProUGUI gameOverText;

    public GameObject[] enemyPrefabs;

    private float spawnLimitUp = 14f;
    private float spawnLimitDown = -14f;
    private float spawnPosY = -16;

    private float startDelay = 1.0f;

    public float sideSpawnX;
    public float sideSpawnMin;
    public float sideSpawnMax;

    private float elapsedTime = 0f;
    private float intervalDecreaseTime = 30f; // Time after which to decrease the interval
    private float minInterval = 2.0f; // Minimum interval to prevent spawning too fast

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            isGameActive = true;

            if (isGameActive)
            {
                StartCoroutine(SpawnRandomEnemy());
                StartCoroutine(SpawnRightEnemy());
                StartCoroutine(SpawnLeftEnemy());
            }
        }
    }

    private IEnumerator SpawnRandomEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        while (isGameActive)
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitUp, spawnLimitDown), spawnPosY, 0);
            Instantiate(enemyPrefabs[randomEnemyIndex], spawnPos, enemyPrefabs[0].transform.rotation);

            float spawnInterval = Mathf.Max(Random.Range(2.5f, 4.5f) - (elapsedTime / intervalDecreaseTime), minInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator SpawnRightEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        while (isGameActive)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(-sideSpawnX, Random.Range(sideSpawnMin, sideSpawnMax), 0);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity);

            float spawnInterval = Mathf.Max(Random.Range(2.5f, 4.5f) - (elapsedTime / intervalDecreaseTime), minInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private IEnumerator SpawnLeftEnemy()
    {
        yield return new WaitForSeconds(startDelay);

        while (isGameActive)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(sideSpawnX, Random.Range(sideSpawnMin, sideSpawnMax), 0);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, Quaternion.identity);

            float spawnInterval = Mathf.Max(Random.Range(2.5f, 4.5f) - (elapsedTime / intervalDecreaseTime), minInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        if (isGameActive)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public void GameOver()
    {
        //gameOverText.gameObject.SetActive(true);
        StopAllCoroutines();
        isGameActive = false;
        SceneManager.LoadScene("YouLoseScene");
    }
}


