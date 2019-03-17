using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Silver : MonoBehaviour
{

    public Button exit;
    public Toggle toggle0, toggle1, toggle2, toggle3, toggle4;
    public InputField ScoreField, EnemiesField;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(exitClick);
        ScoreField.text = "200";
        EnemiesField.text = "2";
    }

    void exitClick()
    {
        int scoreTemp = Int32.Parse(ScoreField.text);
        int enemyTemp = Int32.Parse(EnemiesField.text);
        if (scoreTemp > Main.gv[0].score && enemyTemp > Main.gv[0].MaxEnemies)
        {
            bool[] temp = { toggle0.isOn, toggle1.isOn, toggle2.isOn, toggle3.isOn, toggle4.isOn };
            Main.gv[1] = new GameLevel(Int32.Parse(ScoreField.text), Int32.Parse(EnemiesField.text), temp);
            SceneManager.LoadScene("GoldScene");
        }
        else
        {
            if (enemyTemp <= Main.gv[0].MaxEnemies)
            {
                int num = Int32.Parse(EnemiesField.text);
                num = Main.gv[0].MaxEnemies + 1;
                EnemiesField.text = num.ToString();
                EnemiesField.image.color = Color.red;
            }

            if (scoreTemp <= Main.gv[0].score)
            {
                int num = Int32.Parse(ScoreField.text);
                num = Main.gv[0].score + 50;
                ScoreField.text = num.ToString();
                ScoreField.image.color = Color.red;
            }
        }
    }
}
