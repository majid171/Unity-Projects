using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button levels, config, history, play, exit;

    // Start is called before the first frame update
    void Start()
    {
        levels.onClick.AddListener(levelsClick);
        config.onClick.AddListener(configClick);
        history.onClick.AddListener(historyClick);
        play.onClick.AddListener(playClick);
        exit.onClick.AddListener(exitClick);

    }

    void levelsClick()
    {
        SceneManager.LoadScene("LevelsScene");
    }

    void configClick()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    void historyClick()
    {

    }

    void playClick()
    {
        SceneManager.LoadScene("_Scene_0");
    }

    void exitClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
