using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{

    public Button gold, silver, bronze, exit;

    // Start is called before the first frame update
    void Start()
    {
        gold.onClick.AddListener(goldClick);
        silver.onClick.AddListener(silverClick);
        bronze.onClick.AddListener(bronzeClick);
        exit.onClick.AddListener(exitClick);
    }

    void goldClick()
    {
        SceneManager.LoadScene("GoldScene");
    }

    void silverClick()
    {
        SceneManager.LoadScene("SilverScene");
    }

    void bronzeClick()
    {
        SceneManager.LoadScene("BronzeScene");
    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
