using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource sfxSource;
    public AudioSource MusicSource;

    public AudioClip sfxDamage;
    public AudioClip sfxShoot;
    public AudioClip sfxJump;
    public AudioClip sfxEnemyDie;




    public void playSFX(AudioClip sfxClip, float volume)
    {
        sfxSource.PlayOneShot(sfxClip, volume);

    }

    public void playMusic(AudioClip sfxMusic, float volume)
    {
        MusicSource.PlayOneShot(sfxMusic, volume);
    }
       

}
