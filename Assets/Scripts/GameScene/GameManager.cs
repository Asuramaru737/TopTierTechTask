using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject scoreObj;
    public GameObject pointSpawner;
    public GameObject obstacleSpawner;
    public GameObject explosionEffect;
    public SoundController soundController;

    public TextMeshProUGUI scoreText;

    private ObstacleSpawnerController obstacleSpawnerController;
    private PointSpawnerController pointSpawnerController;
    private PlayerController playerController;
    private ScoreUpAnim scoreUpAnim;
    
    public static int score;
    private bool isDeathAnimPlayed = false;
    

    void Start()
    {
        InstantiateObjects();
        score = 0;
        obstacleSpawnerController.StartSpawn();
        pointSpawnerController.StartSpawn();
    }

    void Update()
    {
        CheckPlayerDeath();
    }

    private void InstantiateObjects(){
        obstacleSpawnerController = obstacleSpawner.GetComponent<ObstacleSpawnerController>();
        pointSpawnerController = pointSpawner.GetComponent<PointSpawnerController>();
        playerController = player.GetComponent<PlayerController>();
        scoreUpAnim = scoreObj.GetComponent<ScoreUpAnim>();
    }

    private void CheckPlayerDeath(){
        if(playerController.IsDestroyed && !isDeathAnimPlayed){
            StartDeathAnimAndDestroyPlayer();
            obstacleSpawnerController.StopSpawn();
            pointSpawnerController.StopSpawn();
            RemoveObjectsAnimation();

            Invoke("LoadEndScene", 2f);
        }
    }

    private void StartDeathAnimAndDestroyPlayer(){
        player.SetActive(false);
        Instantiate(explosionEffect, player.transform.position, Quaternion.identity);
        isDeathAnimPlayed = true;
    }

    public void AddPoint(){
        score++;
        scoreText.text = score.ToString();
        scoreUpAnim.TriggerScoreUpAnim();
        soundController.TriggerPointSound();
    }

    private void RemoveObjectsAnimation(){
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach(var o in objects){
            if(o.gameObject.tag == "Point"){
                o.gameObject.GetComponent<PointController>().StopMoving();
                o.gameObject.GetComponent<PointController>().StartScaleAnim();
            }
            if(o.gameObject.tag == "Obstacle"){
                o.gameObject.GetComponent<ObstacleController>().StopMovingAndStartScaleAnim();
            }
        }
    }

    private void LoadEndScene(){
        SceneManager.LoadScene("EndScene");
    }
}
