using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnerController : MonoBehaviour
{
    public GameObject point;
    private float delay = 1.8f;
    private float highestSpawnPoint = 0.8f;
    private float lowestSpawnPoint = -0.8f;
    private float pointLifetime = 7.5f;
    private bool isSpawning = true;

    void Start()
    {
        
    }

    public void StartSpawn(){
        StartCoroutine(SpawnPoint());
    }

    public void StopSpawn(){
        isSpawning = !isSpawning;
    }

    private IEnumerator SpawnPoint(){
        while(isSpawning){
            var spawnRange = Random.Range(highestSpawnPoint, lowestSpawnPoint);
            var position = new Vector3(transform.position.x, spawnRange);
            GameObject pointClone = Instantiate(point, position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
            Destroy(pointClone, pointLifetime);
        }
        
    }

}
