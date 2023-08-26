using System.Collections.Generic;
using UnityEngine;

public class RandomSoundOnAwake : MonoBehaviour
{
    public List<AudioClip> audioClips;
    private AudioSource thisAudioSource;

    void Awake()
    {
        // Get component
        thisAudioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        // Play sound
        AudioClip audioClip = audioClips[Random.Range(0, audioClips.Count)];
        thisAudioSource.PlayOneShot(audioClip);
    }
}
