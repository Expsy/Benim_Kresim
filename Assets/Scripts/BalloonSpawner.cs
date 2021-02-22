using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{

    public GameObject balloon;
    private float defaultSpawnTimer = 1; //How often do balloons will spawn

    private BalloonManager balloonManager;
    public bool IsSpawning = true;

    public float spawnBarBoundX;


    // Start is called before the first frame update
    void Start()
    {
        spawnBarBoundX = GetComponent<BoxCollider2D>().bounds.size.x/2;
        balloonManager = BalloonManager.instance;
        
        StartCoroutine(BalloonSpawnCoroutine());
        StartCoroutine(SpawnRateControlCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBalloon()
    {
        float spawnLocationX = Random.Range(-spawnBarBoundX, spawnBarBoundX);
        Vector3 spawnlocation = new Vector3(spawnLocationX, transform.position.y, balloon.transform.position.z);
        Instantiate(balloon, spawnlocation, Quaternion.identity);
    }

    void IncreaseSoawnRate()
    {
        defaultSpawnTimer -= balloonManager.difficultyStepRate;
    }

    IEnumerator BalloonSpawnCoroutine()
    {
        while (balloonManager.gameIsOn && IsSpawning)
        {
            SpawnBalloon();
            balloonManager.totalBalloonsCount += 1;
            if (balloonManager.totalBalloonsCount >= 5)
            {
                IsSpawning = false;
                StartCoroutine(EndTheGame());
            }
            yield return new WaitForSeconds(defaultSpawnTimer);
        }
    }
    
    IEnumerator SpawnRateControlCoroutine()
    {
        while (balloonManager.gameIsOn && balloonManager.difficulty < balloonManager.maxDifficulty)
        {
            yield return new WaitForSeconds(balloonManager.difficultyStepTimer);
            IncreaseSoawnRate();
            balloonManager.difficulty += 1;
            if (balloonManager.difficulty == balloonManager.maxDifficulty)
            {
                StopCoroutine(SpawnRateControlCoroutine());
            }
        }
    }

    IEnumerator EndTheGame()
    {
        
        yield return new WaitForSeconds(7);
        balloonManager.EndGame();
    }
}
