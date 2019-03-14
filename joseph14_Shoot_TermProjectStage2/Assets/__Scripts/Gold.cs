using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Gold : MonoBehaviour
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
        
        if (!string.Equals("", EnemiesField.text) && !string.Equals("", ScoreField.text))
        {
            if (Int32.Parse(EnemiesField.text) <= Main.gv[1].MaxEnemies)
            {
                int num = Int32.Parse(EnemiesField.text);
                num++;
                EnemiesField.text = num.ToString();
                EnemiesField.image.color = Color.red;
            }

            bool[] temp = { toggle0.isOn, toggle0.isOn, toggle0.isOn, toggle1.isOn, toggle1.isOn, toggle2.isOn, toggle2.isOn, toggle3.isOn, toggle3.isOn, toggle4.isOn, toggle4.isOn };
            Main.gv[2] = new GameLevel(Int32.Parse(ScoreField.text), Int32.Parse(EnemiesField.text), temp);
        }
        
    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
