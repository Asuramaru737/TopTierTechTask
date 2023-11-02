using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    private SpriteRenderer sr;
    private float pointSpeed = 1f;
    private float pointRotationSpeed = 100f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * pointSpeed;
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, pointRotationSpeed * Time.deltaTime * -1));
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Obstacle"){
            Destroy(this.gameObject);
        }
    }

    public void StartFadeAnim(){
        StopMoving();
        StartCoroutine(FadeAnimation());
    }

    private IEnumerator FadeAnimation(){
        float time = 0.0f;
        float duration = 0.4f;

        while(time < duration){
            float alpha = Mathf.Lerp(1f, 0.0f, time / duration);
            Color newColor = sr.color;
            newColor.a = alpha;
            sr.color = newColor;

            time += Time.deltaTime;
            yield return null;
        }

        this.gameObject.SetActive(false);
    }

    public void StopMoving(){
        pointSpeed = 0;
    }

    public void StartScaleAnim(){
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
