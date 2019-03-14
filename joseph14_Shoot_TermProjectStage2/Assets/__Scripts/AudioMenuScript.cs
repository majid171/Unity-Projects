using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioMenuScript : MonoBehaviour
{

    public Button exit;
    public Dropdown d1, d2, d3, d4;
    public Slider s1, s2, s3, s4;
    public static int d1Val = 0, d2Val = 0, d3Val = 0, d4Val = 0;
    public static float d1Vol = 1.0f, d2Vol = 1.0f, d3Vol = 1.0f, d4Vol = 1.0f;
    public AudioSource[] s;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponents<AudioSource>();
        StopAllSounds();
        exit.onClick.AddListener(exitClick);
        d1.onValueChanged.AddListener(delegate {
            StopAllSounds();
            int index = d1.value + 0;
            s[index].Play();
        });

        d3.onValueChanged.AddListener(delegate {
            StopAllSounds();
            int index = d3.value + 3;
            s[index].Play();

        });

        d4.onValueChanged.AddListener(delegate {
            StopAllSounds();
            int index = d4.value + 5;
            s[index].Play();

        });

        d2.onValueChanged.AddListener(delegate {
            StopAllSounds();
            int index = d2.value + 8;
            s[index].Play();
        });
    }

    // Update is called once per frame
    void Update()
    {
        d1Val = d1.value;
        d2Val = d2.value;
        d3Val = d3.value;
        d4Val = d4.value;

        d1Vol = s1.value;
        d2Vol = s2.value;
        d3Vol = s3.value;
        d4Vol = s4.value;
    }

    void exitClick()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    public void StopAllSounds()
    {
        for (int i = 0; i < s.Length; i++)
        {
            s[i].Stop();
        }
    }
    
}
