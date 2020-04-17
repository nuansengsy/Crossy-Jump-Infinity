using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    [Range(0f, 1f)]
    public float volume;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
}
public class SoundController : MonoBehaviour
{
    public static SoundController SharedInstance;
    public List<Sound> soundsList;

    void Awake()
    {
        SharedInstance = this;

        foreach (Sound s in soundsList)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;

            if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 0)
            {
                s.source.mute = false;
            }
            else
            {
                if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 1)
                {
                    s.source.mute = true;
                }
            }
        }
    }

    public void PlaySound(string soundName)
    {
        foreach (Sound s in soundsList)
        {
            if (s.name == soundName)
            {

                s.source.Play();
            }
        }
    }

    public void MuteSound()
    {

        if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 1)
        {
            PlayerPrefs.SetInt("AudioIsMuted", 0); // for unmute
            foreach (Sound s in soundsList)
            {
                s.source.mute = false;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("AudioIsMuted", 0) == 0)
            {
                PlayerPrefs.SetInt("AudioIsMuted", 1); // for for mute
                foreach (Sound s in soundsList)
                {
                    s.source.mute = true;
                }

            }
        }
    }
}
