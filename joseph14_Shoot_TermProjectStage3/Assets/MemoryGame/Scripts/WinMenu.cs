using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public Button Quit;
    public Button NewGame;
    public Text timeText;
    public Text scoreText;
    public AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {
        Quit.onClick.AddListener(quitClick);
        NewGame.onClick.AddListener(NewGameClick);
        winSound = GetComponent<AudioSource>();
        winSound.Play();
        timeText.GetComponent<Text>().text = "Total Time: " + GameScene.totalTime.ToString("F0");
        scoreText.GetComponent<Text>().text = "Score: " + GameScene.score;
    }

    void NewGameClick()
    {
        SceneManager.LoadScene("GameSceneMemory");
    }

    void quitClick()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
