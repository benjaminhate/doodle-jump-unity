using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jumpSound;
    public AudioClip deathSound;

    public void PlayJumpSound()
    {
        source.clip = jumpSound;
        source.Play();
    }

    public void PlayDeathSound()
    {
        source.clip = deathSound;
        source.Play();
    }
}
