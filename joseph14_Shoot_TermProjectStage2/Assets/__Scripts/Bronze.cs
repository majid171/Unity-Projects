using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Bronze : MonoBehaviour
{

    public Button exit;
    public Toggle toggle0, toggle1, toggle2, toggle3, toggle4;
    public InputField ScoreField, EnemiesField;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(exitClick);
    }

    // Update is called once per frame
    void Update()
    {
        bool[] temp = { toggle0.isOn, toggle0.isOn, toggle0.isOn, toggle1.isOn, toggle1.isOn, toggle2.isOn, toggle2.isOn, toggle3.isOn, toggle3.isOn, toggle4.isOn, toggle4.isOn };
        Main.gv[0] = new GameLevel(Int32.Parse(ScoreField.text), Int32.Parse(EnemiesField.text), temp);
    }

    void exitClick()
    {
        SceneManager.LoadScene("SilverScene");
    }
}
