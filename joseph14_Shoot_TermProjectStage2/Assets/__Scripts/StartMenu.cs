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
        InitGV();
    }

    void quitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void startClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void InitGV()
    {
        Main.gv = new GameLevel[3];
        bool[] temp = { true, true, true, true, true };

        Main.gv[0] = new GameLevel(100, 3, temp);
        Main.gv[1] = new GameLevel(150, 3, temp);
        Main.gv[2] = new GameLevel(200, 3, temp);
    }
}
