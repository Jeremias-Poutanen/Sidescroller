using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstacleSpawner;
    [SerializeField] GameObject[] obstacleArray;
    int obstacleRng;
    float spawnSpeed = 3f;
    Vector3 pos;
    Quaternion rot;
    IEnumerator coroutine;

    void Start()
    {
        coroutine = SpawnObstacles(spawnSpeed);
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnObstacles(float spawnSpeed)
    {
        while (true)
        {
            float spawnSpeedRandomness;
            obstacleRng = Random.Range(0, obstacleArray.Length);
            pos = obstacleSpawner.transform.position;
            rot = obstacleSpawner.transform.rotation;

            spawnSpeedRandomness = spawnSpeed - Random.Range(0.5f, 2f);

            Instantiate(obstacleArray[obstacleRng], pos, rot);
            yield return new WaitForSeconds(spawnSpeedRandomness); ;
        }
    }
}
