using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource;
    public AudioSource effectSource;
    public AudioClip[] musicClips;
    public AudioClip[] effectClips;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [ContextMenu("TestRandomEffect")]
    public void TestRandomEffect()
    {
        RandomPlayEffect();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        RandomVolume(musicSource);
        RandomPitch(musicSource);
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        
        effectSource.PlayOneShot(clip);
    }
    public void RandomPlayMusic()
    {
        int index = Random.Range(0, musicClips.Length);
        
        PlayMusic(musicClips[index]);
    }

    public void RandomPlayEffect()
    {
        RandomPitch(effectSource);
        RandomVolume(effectSource);
        int index = Random.Range(0, effectClips.Length);
        PlayEffect(effectClips[index]);
    }

    public void RandomVolume(AudioSource source)
    {
        source.volume = Random.Range(0.5f, 1f);
        Debug.Log("Random Volume: " + source.volume);
    }

    public void RandomPitch(AudioSource source)
    {
        source.pitch = Random.Range(0.5f, 1.5f);
        Debug.Log("Random Pitch: " + source.pitch);
    }

}
