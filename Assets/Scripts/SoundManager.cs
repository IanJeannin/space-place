using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private static AudioSource audio;

    private void Start()
    {
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>(); //Sets the scenes audio source to audio
    }


    public void PickupSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("PickupSound"));
    }

    public void CheckpointSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("CheckPointSound"));
    }

    public void DoorSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("NextLevelSound"));
    }

    public void ButtonSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("Clicks_13"));
    }

    public void JumpSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("Landing_01"));
    }

    public void DeathSound()
    {
        audio.PlayOneShot(Resources.Load<AudioClip>("Male_Death_04"));
    }

}
