using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        
    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
