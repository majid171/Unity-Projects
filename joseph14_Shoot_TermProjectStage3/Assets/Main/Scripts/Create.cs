using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Create : MonoBehaviour
{

    public Button save, exit;
    public InputField username;
    public Text invalid;

    // Start is called before the first frame update
    void Start()
    {
        save.onClick.AddListener(saveClick);
        exit.onClick.AddListener(exitClick);
    }

    public void saveClick()
    {
        if (!contains(username.text))
        {
            Login.auth.users.Add(new User(username.text, username.text, "NEW"));
            Login.WriteData();
        }
        else
        {
            invalid.text = "User Already Exists";
        }

        SceneManager.LoadScene("UserAccounts");
    }

    public void exitClick()
    {
        SceneManager.LoadScene("UserAccounts");
    }

    public bool contains(string user)
    {

        for (int i = 0; i < Login.auth.users.Count; i++)
        {
            if (Login.auth.users[i].username == username.text)
            {
                return true;
            }
        }

        return false;
    }
}
