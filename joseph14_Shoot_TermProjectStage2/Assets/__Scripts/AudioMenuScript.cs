using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioMenuScript : MonoBehaviour
{

    public Button exit;


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
        SceneManager.LoadScene("ConfigMenu");
    }
}
