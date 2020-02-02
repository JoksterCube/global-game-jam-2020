using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> rippleSounds;
    public AudioClip mainTheme;
    public AudioClip deathClip;
    public AudioClip victoryClip;

    public AudioSource musicSource;

    public AudioClip GetRippleSound()
    {
        int index = Random.Range(0, rippleSounds.Count);

        return rippleSounds[index];
    }

    public void PlayDeath()
    {
        musicSource.clip = deathClip;
        musicSource.loop = false;
        musicSource.Play();
    }
}

