using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int rotationSpeed = 190;
    private GameObject player;

    public SoundController soundController;
    public bool IsDestroyed {get; set;} = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        ChangeRotationDirection();
        
    }

    private void ChangeRotationDirection(){
        if(Input.GetMouseButtonDown(0)){
            rotationSpeed *= -1;
            if(player.activeInHierarchy) soundController.TriggerChangedDirectionSound();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Obstacle"){
            IsDestroyed = true;
        }

        if(col.gameObject.tag == "Point"){
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("GameManager").gameObject.SendMessage("AddPoint");
            col.gameObject.SendMessage("StartFadeAnim");
        }
    }

}
