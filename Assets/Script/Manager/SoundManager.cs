using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource musicSource;
    public AudioSource effectSource;
    [SerializeField]
    public List<Sound> musicClips;
    public List<Sound> effectClips;
    private AudioClip currentMusic;
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

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayEffect(AudioClip clip)
    {
        
        effectSource.PlayOneShot(clip);
    }
    public void PlayEffect(string name)
    {
        if (effectClips.Find(x => x.name == name) != null)
        {
            AudioClip clip = effectClips.Find(x => x.name == name).clip;
            effectSource.PlayOneShot(clip);
            
        }
        else
        {
            AudioClip clip2 = effectClips.Find(x => x.name == "default").clip;
            effectSource.PlayOneShot(clip2);
        }
    }

    private void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        AudioClip clip;
        // 定义正则表达式，匹配多个场景名称
        Match match = Regex.Match(currentScene, @"(MainMenu|Childhood*|Midlife*|Adolescent*|Old*|ending*)");
        if (match.Success)
        {
            if (musicClips.Find(x => x.name == match.Value) != null)
            {
                Debug.LogWarning("Play music in " + match.Value);
                clip = musicClips.Find(x => x.name == match.Value).clip;
                if (clip!= currentMusic)
                {
                    currentMusic = clip;
                    PlayMusic(currentMusic);
                }
            }
            
        }
        
        
    }

    

}
