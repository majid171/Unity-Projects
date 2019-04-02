using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toolbar : MonoBehaviour
{
    public Button file, shoot, apple, rps, memory;
    public static bool isAdmin;
    public static int game;
    public static bool isGame;

    // Start is called before the first frame update
    void Start()
    {
        file.onClick.AddListener(fileClick);
        shoot.onClick.AddListener(shootClick);
        apple.onClick.AddListener(appleClick);
        rps.onClick.AddListener(rpsClick);
        memory.onClick.AddListener(memoryClick);
        isGame = false;
        isAdmin = checkIfAdmin();
        AudioBG.ResumeMusic();
    }

    void fileClick()
    {
        AudioBG.ButtonSound();
        SceneManager.LoadScene("File");
    }

    void shootClick()
    {
        AudioBG.ButtonSound();
        game = 0;
        AudioBG.PauseMusic();
        SceneManager.LoadScene("StartScene");
    }

    void appleClick()
    {
        AudioBG.ButtonSound();
        game = 1;
        SceneManager.LoadScene("GameMenu");
    }

    void rpsClick()
    {
        AudioBG.ButtonSound();
        game = 2;
        SceneManager.LoadScene("GameMenu");
    }

    void memoryClick()
    {
        AudioBG.ButtonSound();
        game = 3;
        SceneManager.LoadScene("GameMenu");
    }

    public static bool checkIfAdmin()
    {
        return Login.auth.users[Login.UserIndex].username == "admin" && Login.auth.users[Login.UserIndex].password == "admin";
    }
}
