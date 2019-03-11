using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;

    // Start is called before the first frame update
    void Start()
    {
        b1.onClick.AddListener(b1Click);
        b2.onClick.AddListener(b2Click);
        b3.onClick.AddListener(b3Click);
        b4.onClick.AddListener(b4Click);
        b5.onClick.AddListener(b5Click);
    }

    // Series of functions to update card amount
    public void b1Click()
    {
        GameScene.numberOfCards = 12;
        goBack();
    }

    public void b2Click()
    {
        GameScene.numberOfCards = 14;
        goBack();
    }

    public void b3Click()
    {
        GameScene.numberOfCards = 16;
        goBack();
    }

    public void b4Click()
    {
        GameScene.numberOfCards = 18;
        goBack();
    }

    public void b5Click()
    {
        GameScene.numberOfCards = 20;
        goBack();
    }

    public void goBack()
    {
        SceneManager.LoadScene("GameScene");
    }
}
