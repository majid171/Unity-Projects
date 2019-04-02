using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button levels, config, history, play, exit;
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        click.Stop();
        levels.onClick.AddListener(levelsClick);
        config.onClick.AddListener(configClick);
        history.onClick.AddListener(historyClick);
        play.onClick.AddListener(playClick);
        exit.onClick.AddListener(exitClick);
    }

    void levelsClick()
    {
        click.Play();
        SceneManager.LoadScene("LevelsScene");
    }

    void configClick()
    {
        click.Play();
        SceneManager.LoadScene("ConfigScene");
    }

    void historyClick()
    {
        click.Play();
        toolbar.isGame = true;
        toolbar.game = 0;
        SceneManager.LoadScene("History");
    }

    void playClick()
    {
        click.Play();
        SceneManager.LoadScene("_Scene_0");
    }

    void exitClick()
    {
        click.Play();
        SceneManager.LoadScene("StartScene");
    }

    
}
