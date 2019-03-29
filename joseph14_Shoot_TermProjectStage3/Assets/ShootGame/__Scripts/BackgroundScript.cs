using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundScript : MonoBehaviour
{

    public Button exit;
    public Dropdown dp;
    public static int dpValue;
    public Image img;
    public Sprite img1, img2, img3;
    public Slider xSlide, ySlide;
    public static int xScale = 80, yScale = 80;

    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(exitClick);
    }

    // Update is called once per frame
    void Update()
    {
        dpValue = dp.value;
        if (dpValue == 0)
        {
            img.sprite = img1;
        }
        else if (dpValue == 1)
        {
            img.sprite = img2;
        }
        else if (dpValue == 2)
        {
            img.sprite = img3;
        }

        xScale = (int)Mathf.Round(xSlide.value) * 10;
        yScale = (int)Mathf.Round(ySlide.value) * 10;
    }

    void exitClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
