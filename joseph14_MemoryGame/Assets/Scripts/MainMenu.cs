using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button startButton, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startClick);
        exitButton.onClick.AddListener(exitClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void exitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void startClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
