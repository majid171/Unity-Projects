using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toolbar : MonoBehaviour
{
    public Button file, shoot, apple, rps, memory;
    public static bool isAdmin;

    // Start is called before the first frame update
    void Start()
    {
        file.onClick.AddListener(fileClick);
        shoot.onClick.AddListener(shootClick);
        apple.onClick.AddListener(appleClick);
        rps.onClick.AddListener(rpsClick);
        memory.onClick.AddListener(memoryClick);

        isAdmin = checkIfAdmin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void fileClick()
    {
        AudioBG.ButtonSound();

        SceneManager.LoadScene("File");
    }

    void shootClick()
    {
        AudioBG.ButtonSound();

    }

    void appleClick()
    {
        AudioBG.ButtonSound();

    }

    void rpsClick()
    {
        AudioBG.ButtonSound();

    }

    void memoryClick()
    {
        AudioBG.ButtonSound();

    }

    public static bool checkIfAdmin()
    {
        return Login.auth.users[Login.UserIndex].username == "admin" && Login.auth.users[Login.UserIndex].password == "admin";
    }
}
