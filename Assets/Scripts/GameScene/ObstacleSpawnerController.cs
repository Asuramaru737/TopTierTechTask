using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerController : MonoBehaviour
{
    public GameObject obstacle;
    private float delay = 1.45f;
    private float highestPoint = 1f;
    private float lowestPoint = -1f;
    private float obstacleLifetime = 8.5f;
    private bool isSpawning = true;

    void Start()
    {

    }

    public void StartSpawn(){
        StartCoroutine(SpawnObstacle());
    }

    public void StopSpawn(){
        isSpawning = !isSpawning;
    }

    private IEnumerator SpawnObstacle(){
        while(isSpawning){
            var spawnRange = Random.Range(highestPoint, lowestPoint);
            var position = new Vector3(transform.position.x, spawnRange);
            GameObject obstacleClone = Instantiate(obstacle, position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
            Destroy(obstacleClone, obstacleLifetime);
        }
    }

}
