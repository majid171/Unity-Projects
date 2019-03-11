using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Button quit;
    public Button start;

    // Start is called before the first frame update
    void Start()
    {
        quit.onClick.AddListener(quitClick);
        start.onClick.AddListener(startClick);
    }

    void quitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void startClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
