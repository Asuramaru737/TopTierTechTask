using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float obstacleSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * obstacleSpeed);
    }

    public void StopMovingAndStartScaleAnim(){
        obstacleSpeed = 0;
        Invoke("StartAnim", 1);
    }

    private void StartAnim(){
        StartCoroutine(ScaleAnim());
    }

    private IEnumerator ScaleAnim(){
        float speed = 2f;
        Vector3 scale = transform.localScale;
        Vector3 targetScale = new Vector3(0,0,0);

        while(scale != targetScale){
            scale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
            transform.localScale = scale;
            yield return null;
        }
    }

}
