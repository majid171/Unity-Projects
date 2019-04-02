using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioMain : MonoBehaviour
{

    public Button save;
    public Dropdown dp;
    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        AudioBG.PauseMusic();
        save.onClick.AddListener(saveClick);
        sounds = GetComponents<AudioSource>();
 
        dp.onValueChanged.AddListener(delegate
        {
            StopAllSounds();
            sounds[dp.value].Play();
        });
    }

    public void saveClick()
    {
        StopAllSounds();
        AudioBG.ButtonSound();

        AudioBG.AudioIndex = dp.value;
        AudioBG.PlayMusic();
        //AudioBG.ResumeMusic();
        SceneManager.LoadScene("Configurations");
    }
    
    public void StopAllSounds()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }
}
