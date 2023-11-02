using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource soundSrc;
    public AudioClip pointSound, changedDirectionSound;

    public void TriggerPointSound(){
        soundSrc.clip = pointSound;
        soundSrc.Play();
    }

    public void TriggerChangedDirectionSound(){
        soundSrc.clip = changedDirectionSound;
        soundSrc.Play();
    }
}
