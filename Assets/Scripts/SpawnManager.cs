using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject ditchPrefab;
    public GameObject sandStormPrefab;
    public GameObject shieldPrefab;

    public bool isGameActive;
    public int obstacleCount;
    public int levelNumber = 1;

    private float xSpawnRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        obstacles = new GameObject[]{ditchPrefab, sandStormPrefab, shieldPrefab};

        StartCoroutine(SpawnObstacleWave(levelNumber));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (obstacleCount == 0)
        {
            SpawnObstacleWave(++levelNumber);
            Instantiate(shieldPrefab, GenerateSpawnPosition(), transform.rotation);
        } */
    }

    IEnumerator SpawnObstacleWave(int obstaclesToSpawn)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(5); // spawn rate
            for (int i = 0; i < obstaclesToSpawn; i++)
            {
                Instantiate(obstacles[Random.Range(0, obstacles.Length)], GenerateSpawnPosition(), transform.rotation);
            }

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-xSpawnRange, xSpawnRange);
        float spawnPosZ = Random.Range(-xSpawnRange, xSpawnRange);
        
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

}
