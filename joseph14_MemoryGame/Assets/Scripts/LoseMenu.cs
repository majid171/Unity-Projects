using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public Button quit;
    public Button NewGame;
    public Text timeText;
    public AudioSource LoseSound;

    // Start is called before the first frame update
    void Start()
    {
        quit.onClick.AddListener(quitClick);
        NewGame.onClick.AddListener(NewGameClick);
        LoseSound = GetComponent<AudioSource>();
        LoseSound.Play();
        timeText.GetComponent<Text>().text = "Total Time: " + GameScene.totalTime.ToString("F0");
    }

    void quitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void NewGameClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
