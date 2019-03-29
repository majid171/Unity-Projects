using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class file : MonoBehaviour
{

    public Button accts, config, history, logout;
    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        accts.onClick.AddListener(acctsClick);
        config.onClick.AddListener(configClick);
        history.onClick.AddListener(historyClick);
        logout.onClick.AddListener(logoutClick);

        sounds = GetComponents<AudioSource>();
        sounds[Login.audioIndex].Play();


    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acctsClick()
    {
        SceneManager.LoadScene("UserAccounts");
    }

    public void configClick()
    {
        SceneManager.LoadScene("Configurations");
    }

    public void historyClick()
    {
        SceneManager.LoadScene("History");
    }

    public void logoutClick()
    {
        Login.auth.users[Login.UserIndex].history.durations.Add((Math.Truncate((System.DateTime.Now.Subtract(Login.initial).TotalMinutes) * 100.0) / 100.0).ToString());
        Login.WriteData();
        Login.reset();
        SceneManager.LoadScene("MainLogin");
    }
}
