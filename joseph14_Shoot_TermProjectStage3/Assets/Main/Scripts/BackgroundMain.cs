using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundMain : MonoBehaviour
{

    public Button save;
    public Dropdown options;
    public Image img;
    public Sprite bg1, bg2;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        save.onClick.AddListener(saveClick);
    }

    void Update()
    {
        if (options.value == 0)
        {
            img.sprite = bg1;
        }
        else if (options.value == 1)
        {
            img.sprite = bg2;
        }
    }

    public void saveClick()
    {
        AudioBG.ButtonSound();

        if (options.value == 0)
        {
            mat.mainTexture = bg1.texture;
        }
        else if(options.value == 1)
        {
            mat.mainTexture = bg2.texture;
        }

        SceneManager.LoadScene("Configurations");
    }

}
