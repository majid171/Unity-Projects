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

    }

    void silverClick()
    {

    }

    void bronzeClick()
    {

    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
