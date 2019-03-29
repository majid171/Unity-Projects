using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserAccounts : MonoBehaviour
{

    public Button create, delete, change, release, exit;
    public AudioSource[] sounds;
    public Text invalid;

    // Start is called before the first frame update
    void Start()
    {
        create.onClick.AddListener(createClick);
        delete.onClick.AddListener(deleteClick);
        change.onClick.AddListener(changeClick);
        release.onClick.AddListener(releaseClick);
        exit.onClick.AddListener(exitClick);

        sounds = GetComponents<AudioSource>();
        sounds[Login.audioIndex].Play();
    }

    public void createClick()
    {
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
        SceneManager.LoadScene("Change");
    }

    public void releaseClick()
    {

    }

    public void exitClick()
    {
        SceneManager.LoadScene("File");
    }
}
