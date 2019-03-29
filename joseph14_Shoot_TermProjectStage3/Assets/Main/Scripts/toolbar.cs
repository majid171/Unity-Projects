using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toolbar : MonoBehaviour
{
    public Button file, shoot, apple, rps, memory;
    public AudioSource[] sounds;
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

        sounds = GetComponents<AudioSource>();
        sounds[Login.audioIndex].Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void fileClick()
    {
        SceneManager.LoadScene("File");
    }

    void shootClick()
    {

    }

    void appleClick()
    {

    }

    void rpsClick()
    {

    }

    void memoryClick()
    {

    }

    public static bool checkIfAdmin()
    {
        return Login.auth.users[Login.UserIndex].username == "admin" && Login.auth.users[Login.UserIndex].password == "admin";
    }
}
