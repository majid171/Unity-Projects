using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class configMenu : MonoBehaviour
{
    public Button enemies, myAudio, background, exit;

    // Start is called before the first frame update
    void Start()
    {
        enemies.onClick.AddListener(enemiesClick);
        myAudio.onClick.AddListener(myAudioClick);
        background.onClick.AddListener(backgroundClick);
        exit.onClick.AddListener(exitClick);
    }

    void enemiesClick()
    {
        SceneManager.LoadScene("EnemiesMenu");
    }

    void myAudioClick()
    {
        SceneManager.LoadScene("AudioMenu");
    }

    void backgroundClick()
    {
        SceneManager.LoadScene("BackgroundScene");
    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
