using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Delete : MonoBehaviour
{

    public Button delete, exit;
    public InputField username;
    public Text invalid;

    // Start is called before the first frame update
    void Start()
    {
        delete.onClick.AddListener(deleteClick);
        exit.onClick.AddListener(exitClick);
    }

    public void deleteClick()
    {
        if (username.text == "admin")
        {
            invalid.text = "Cannot delete Admin";
            return;
        }

        if (contains(username.text))
        {
            User toRemove = getUser();
            Login.auth.users.Remove(toRemove);
            Login.WriteData();
            SceneManager.LoadScene("UserAccounts");
        }
        else
        {
            invalid.text = "User Does Not Exist";
        }
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

    public User getUser()
    {

        for (int i = 0; i < Login.auth.users.Count; i++)
        {
            if (Login.auth.users[i].username == username.text)
            {
                return Login.auth.users[i];
            }
        }

        return null;
    }
}
