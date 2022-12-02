using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finale : MonoBehaviour
{
    public FishController fishController;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    bool play;

    void Awake()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (fishController.roomNumber == 5 && play == false)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[1];
            audioSource.Play();
            play = true;
        }
    }
}
