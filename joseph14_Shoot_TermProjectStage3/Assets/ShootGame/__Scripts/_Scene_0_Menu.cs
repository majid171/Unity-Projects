using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _Scene_0_Menu : MonoBehaviour
{
    public Button restart;
    public Button toggle;
    public Button exit;
    public Text BtnTxt;
    public Text scoreTxt;
    public Text enemy0, enemy1, enemy2, enemy3, enemy4;
    public Material bg;
    public Texture img1, img2, img3;
    public GameObject bgImg;
    public Text timeText;
    public static float time;


    // Start is called before the first frame update
    void Start()
    {
        toggle.onClick.AddListener(toggleClick);
        restart.onClick.AddListener(restartClick);
        exit.onClick.AddListener(exitClick);
        bgImg = GameObject.Find("StarfieldBG");
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;
        scoreTxt.GetComponent<Text>().text = "Score: " + Main.score.ToString();
        enemy0.GetComponent<Text>().text = "Enemy 0: " + Main.Enemy0Total.ToString();
        enemy1.GetComponent<Text>().text = "Enemy 1: " + Main.Enemy1Total.ToString();
        enemy2.GetComponent<Text>().text = "Enemy 2: " + Main.Enemy2Total.ToString();
        enemy3.GetComponent<Text>().text = "Enemy 3: " + Main.Enemy3Total.ToString();
        enemy4.GetComponent<Text>().text = "Enemy 4: " + Main.Enemy4Total.ToString();
        
        if (BackgroundScript.dpValue == 0)
        {
            bg.mainTexture = img1;
        }
        else if(BackgroundScript.dpValue == 1)
        {
            bg.mainTexture = img2;
        }
        else if (BackgroundScript.dpValue == 2)
        {
            bg.mainTexture = img3;
        }

        bgImg.transform.localScale = new Vector3(BackgroundScript.xScale, BackgroundScript.yScale, 1);

        timeText.text = time.ToString("F1");
    
    }

    void toggleClick()
    {
        Debug.Log("Clicked Pause/Play");
        if (Main.isPlaying)
        {
            BtnTxt.text = "Play";

            Time.timeScale = 0.0f;
        }
        else
        {
            BtnTxt.text = "Pause";
            Time.timeScale = 1.0f;
        }
        Main.isPlaying = !Main.isPlaying;
    }

    void exitClick()
    {
        // Changed the logic so that a game only counts when you die, not when you exit
        Main.score = 0;
        Main.Enemy0Total = 0;
        Main.Enemy1Total = 0;
        Main.Enemy2Total = 0;
        Main.Enemy3Total = 0;
        Main.Enemy4Total = 0;
        time = 0;
        Main.currLevel = 0;
        SceneManager.LoadScene("MainScene");
    }

    void restartClick()
    {
        Main.isPlaying = true;
        Main.score = 0;
        Main.Enemy0Total = 0;
        Main.Enemy1Total = 0;
        Main.Enemy2Total = 0;
        Main.Enemy3Total = 0;
        Main.Enemy4Total = 0;
        time = 0;
        Main.DestroyAllObjects();
        Main.currLevel = 0;
        //SceneManager.LoadScene("_Scene_0");
    }
}
