using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{

    public Button update;
    public InputField password;
    public Text invalid;

    // Start is called before the first frame update
    void Start()
    {
        update.onClick.AddListener(updateClick);
    }

    public void updateClick()
    {
        AudioBG.ButtonSound();

        if (Login.auth.users[Login.UserIndex].password != password.text)
        {
            Login.auth.users[Login.UserIndex].password = password.text;
            Login.WriteData();

            if (Login.isNew)
            {
                Login.isNew = false;
                SceneManager.LoadScene("Toolbar");
            }
            else
            {
                SceneManager.LoadScene("UserAccounts");
            }
        }
        else
        {
            invalid.text = "Old password cannot be same as new password";
        }
    }
}
