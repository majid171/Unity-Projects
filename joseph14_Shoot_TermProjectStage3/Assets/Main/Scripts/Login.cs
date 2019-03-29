using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Login : MonoBehaviour
{

    public Button ExitButton;
    public Button LoginButton;
    public InputField UsernameField;
    public InputField PasswordField;
    public static AudioSource[] sounds;
    public static int audioIndex = 0;
    public Text invalidText;

    public static Users auth;
    public static int UserIndex;
    public static string path = "Assets/Main/JSON/users.json";
    public static System.DateTime initial;

    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(ExitClick);
        LoginButton.onClick.AddListener(LoginClick);
        sounds = GetComponents<AudioSource>();
        PlaySound();

        // Read from the JSON File to get user list
        auth = GetData();
        UserIndex = -1;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sounds[audioIndex].time);
        
    }

    public void ExitClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoginClick()
    {
        invalidText.text = "";

        for (int i = 0; i < auth.users.Count; i++)
        {
            User current = auth.users[i];
            if (current.username == UsernameField.text && current.password == PasswordField.text)
            {
                UserIndex = i;
                break;
            }
        }

        if (UserIndex < 0)
        {
            invalidText.text = "Invalid Credentials";
        }
        else
        {
            initial = System.DateTime.Now;
            auth.users[UserIndex].history.logins.Add(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            WriteData();

            // If logging in for the first time
            if (auth.users[UserIndex].status == "NEW")
            {
                auth.users[UserIndex].status = "NORMAL";
                WriteData();
                SceneManager.LoadScene("Change");
            }
            else
            {
                SceneManager.LoadScene("toolbar");
            }

        }

        UsernameField.text = "";
        PasswordField.text = "";
    }

    public void PlaySound()
    {
        sounds[audioIndex].Play();
    }

    public Users GetData()
    {
        return JsonUtility.FromJson<Users>(File.ReadAllText(path));
    }

    public static void WriteData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(auth));
    }

    public static void reset()
    {
        UserIndex = - 1;
    }
}
