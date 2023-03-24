using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] 
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource soundSource;

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }


    public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1)
    {
        soundSource.transform.position = pos;
        PlaySound(clip,vol);
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        soundSource.PlayOneShot(clip, volume);
    }
   


}
