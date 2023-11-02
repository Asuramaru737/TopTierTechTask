using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpAnim : MonoBehaviour
{
    public Animator scoreAnimator;

    public void TriggerScoreUpAnim(){
        scoreAnimator.SetTrigger("ScoreUp");
    }
}
