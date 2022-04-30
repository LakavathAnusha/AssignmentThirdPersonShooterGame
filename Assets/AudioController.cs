using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public AudioClip audio;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    public void PlayerRun()
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
