using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneMenu : MonoBehaviour
{

    public Button reset;
    public Button settings;

    // Start is called before the first frame update
    void Start()
    {
        reset.onClick.AddListener(resetClick);
        settings.onClick.AddListener(settingsClick);
    }

    void resetClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    void settingsClick()
    {
        SceneManager.LoadScene("Settings");
    }
}
