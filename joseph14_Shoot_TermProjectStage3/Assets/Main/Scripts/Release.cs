using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Release : MonoBehaviour
{

    public Button free, exit;
    public InputField username;
    public Text info;

    // Start is called before the first frame update
    void Start()
    {
        free.onClick.AddListener(delegate
        {
            AudioBG.ButtonSound();


            bool found = false;
            for (int i = 0; i < Login.auth.users.Count; i++)
            {
                if (username.text == Login.auth.users[i].username)
                {
                    found = true;
                    if (Login.auth.users[i].status == "BLOCKED")
                    {
                        Login.auth.users[i].status = "NEW";
                        Login.auth.users[i].password = username.text;
                        info.text = "User " + username.text + " is Unblocked";
                        Login.auth.users[i].LoginAttempts = 0;
                    }
                    else
                    {
                        info.text = "User " + username.text + " was never blocked";
                    }
                    break;
                }
            }

            if (!found)
            {
                info.text = "User Does Not Exist";
            }
            Login.WriteData();
        });

        exit.onClick.AddListener(delegate {
            AudioBG.ButtonSound();

            SceneManager.LoadScene("UserAccounts");
        });


    }
}
