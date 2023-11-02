using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = GameManager.score.ToString();
    }

    void Update()
    {
        
    }
}
