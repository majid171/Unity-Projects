using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class file : MonoBehaviour
{

    public Button accts, config, history, logout, exit;

    // Start is called before the first frame update
    void Start()
    {
        accts.onClick.AddListener(acctsClick);
        config.onClick.AddListener(configClick);
        history.onClick.AddListener(historyClick);
        logout.onClick.AddListener(logoutClick);

        exit.onClick.AddListener(delegate
        {
            AudioBG.ButtonSound();

            SceneManager.LoadScene("Toolbar");
        });

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acctsClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("UserAccounts");
    }

    public void configClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("Configurations");
    }

    public void historyClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("History");
    }

    public void logoutClick()
    {
        AudioBG.ButtonSound();

        Login.auth.users[Login.UserIndex].history.durations.Add((Math.Truncate((System.DateTime.Now.Subtract(Login.initial).TotalMinutes) * 100.0) / 100.0).ToString());
        Login.WriteData();
        Login.reset();
        SceneManager.LoadScene("MainLogin");
    }
}
