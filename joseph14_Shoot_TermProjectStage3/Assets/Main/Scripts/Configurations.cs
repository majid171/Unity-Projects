using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configurations : MonoBehaviour
{

    public Button audio1, background, exit;

    // Start is called before the first frame update
    void Start()
    {
        audio1.onClick.AddListener(audioClick);
        background.onClick.AddListener(backgroundClick);
        exit.onClick.AddListener(exitClick);
    }

    public void audioClick()
    {
        SceneManager.LoadScene("AudioMain");
    }

    public void backgroundClick()
    {
        SceneManager.LoadScene("BackgroundMain");
    }

    public void exitClick()
    {
        SceneManager.LoadScene("File");
    }
}
