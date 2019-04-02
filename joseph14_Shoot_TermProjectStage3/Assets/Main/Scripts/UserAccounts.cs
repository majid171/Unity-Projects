using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserAccounts : MonoBehaviour
{

    public Button create, delete, change, release, exit;
    public Text invalid;

    // Start is called before the first frame update
    void Start()
    {
        create.onClick.AddListener(createClick);
        delete.onClick.AddListener(deleteClick);
        change.onClick.AddListener(changeClick);
        release.onClick.AddListener(releaseClick);
        exit.onClick.AddListener(exitClick);

    }

    public void createClick()
    {
        AudioBG.ButtonSound();

        if (toolbar.isAdmin)
        {
            SceneManager.LoadScene("Create");
        }
        else
        {
            invalid.text = "Admin's Only";
        }
    }

    public void deleteClick()
    {
        AudioBG.ButtonSound();

        if (toolbar.isAdmin)
        {
            SceneManager.LoadScene("Delete");
        }
        else
        {
            invalid.text = "Admin's Only";
        }
    }

    public void changeClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("Change");
    }

    public void releaseClick()
    {
        AudioBG.ButtonSound();

        if (toolbar.isAdmin)
        {
            SceneManager.LoadScene("Release");
        }
        else
        {
            invalid.text = "Admin's Only";
        }
    }

    public void exitClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("File");
    }
}
