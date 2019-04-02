using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public Button start, exit, history;
    public Text GameText;

    // Start is called before the first frame update
    void Start()
    {

        if (toolbar.game == 0)
        {
            GameText.text = "Shooting-Game";
        }
        else if (toolbar.game == 1)
        {
            GameText.text = "Apple-Picker Game";
        }
        else if (toolbar.game == 2)
        {
            GameText.text = "Rock Paper Scissors Game";
        }
        else if (toolbar.game == 3)
        {
            GameText.text = "Memory Game";
        }

        start.onClick.AddListener(delegate {

            AudioBG.StopAllMusic();

            if (toolbar.game == 0)
            {
                SceneManager.LoadScene("StartScene");
            }
            else if (toolbar.game == 1)
            {
                SceneManager.LoadScene("_Scene_0_Apple");
            }
            else if (toolbar.game == 2)
            {
                SceneManager.LoadScene("Scene0RPS");
            }
            else if (toolbar.game == 3)
            {
                SceneManager.LoadScene("StartMenuMemory");
            }
        });

        exit.onClick.AddListener(delegate {
            AudioBG.PlayMusic();
            SceneManager.LoadScene("Toolbar");
        });

        history.onClick.AddListener(delegate {
            toolbar.isGame = true;
            SceneManager.LoadScene("History");
        });

    }

}
