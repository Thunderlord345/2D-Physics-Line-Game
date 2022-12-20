using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance;

    public MusicClip[] music;

    int i;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (MusicClip m in music)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("Awaken");
    }

    public void Play(string name)
    {
        MusicClip m = Array.Find(music, music => music.name == name);
        if (m == null)
            return;
        m.source.Play();
    }

    public void Stop(string name)
    {
        MusicClip m = Array.Find(music, music => music.name == name);
        if (m == null)
            return;

        m.source.Stop();
    }

    public void Pause(string name)
    {
        MusicClip m = Array.Find(music, music => music.name == name);
        if(m==null)
            return;

        m.source.Pause();
    }

    
}
