using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Button quit;
    public Button start;
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
        click.Stop();
        quit.onClick.AddListener(quitClick);
        start.onClick.AddListener(startClick);
        InitGV();
    }

    void quitClick()
    {
        click.Play();
        //UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("Toolbar");
    }

    void startClick()
    {
        click.Play();
        SceneManager.LoadScene("MainScene");

    }

    public void InitGV()
    {
        Main.gv = new GameLevel[4];
        bool[] temp = { true, true, true, true, true};

        Main.gv[0] = new GameLevel(100, 1, temp);
        Main.gv[1] = new GameLevel(200, 2, temp);
        Main.gv[2] = new GameLevel(300, 3, temp);
        Main.gv[3] = new GameLevel(100000, 4, temp);
    }
}
