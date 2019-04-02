using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBG : MonoBehaviour
{

    public static AudioSource[] sounds;
    public static int AudioIndex = 0;

    // Singelton for the class
    public static AudioBG instance = null;

    
    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
            sounds = GetComponents<AudioSource>();
            PlayMusic();
        }
        
    }

    public static void PlayMusic()
    {
        sounds[AudioIndex].Play();
    }

    public static void PauseMusic()
    {
        sounds[AudioIndex].Pause();
    }

    public static void StopMusic()
    {
        sounds[AudioIndex].Stop();
    }

    public static void ResumeMusic()
    {
        sounds[AudioIndex].UnPause();
    }

    public static void ButtonSound()
    {
        sounds[2].Play();
    }

    public static void StopAllMusic()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }
}
