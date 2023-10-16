using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacleSpawner;
    [SerializeField] GameObject[] obstacleArray;
    GameManager gameManager;
    int obstacleRng;
    float spawnSpeed = 2f;
    public float minSpawnSpeed = 1.5f;
    public float maxSpawnSpeed = 2.5f;
    Vector3 pos;
    Quaternion rot;
    IEnumerator coroutine;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        coroutine = SpawnObstacles(spawnSpeed);
        StartCoroutine(coroutine);
    }

    void Update()
    {
        if(gameManager.gameOver)
        {
            StopCoroutine(coroutine);
        }
    }

    IEnumerator SpawnObstacles(float spawnSpeed)
    {
        while (true)
        {
            obstacleRng = Random.Range(0, obstacleArray.Length);
            pos = obstacleSpawner.transform.position;
            rot = obstacleSpawner.transform.rotation;

            spawnSpeed = Random.Range(minSpawnSpeed, maxSpawnSpeed);

            Instantiate(obstacleArray[obstacleRng], pos, rot);
            yield return new WaitForSeconds(spawnSpeed); ;
        }
    }
}
