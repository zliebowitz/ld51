using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] Sounds;
    public Sound[] Music;
    private Sound _currentMusic;
    private static AudioManager _instance;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);//Keep between scenes.

        if (_instance == null)//Prevents duplication when entering a new scene.
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in Music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void PlaySound(string name, bool loop= false)
    {
        Sound s = Array.Find(Sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.loop = loop;
        s.source.Play();
    }

    public void StopMusic()
    {
        if (_currentMusic != null)
        {
            _currentMusic.source.Stop();
        }
    }

    public void PauseMusic()
    {
        _currentMusic.source.Pause();
    }

    public void ResumeMusic()
    {
        _currentMusic.source.Play();
    }

    public void PlayMusic(string name, bool loop = true)
    {
        StopMusic();//Make sure only one song is playing at a time. 

        _currentMusic = Array.Find(Music, sound => sound.name == name);
        if (_currentMusic == null)
        {
            Debug.LogWarning("Music: " + name + " not found!");
            return;
        }

        _currentMusic.loop = loop;
        _currentMusic.source.Play();
            
    }


}