using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameHistory
{
    public List<string> dates;
    public List<string> scores;
    public List<string> levels;
}

[System.Serializable]
public class History
{
    public List<string> logins;
    public List<string> durations;
    public GameHistory MemoryGame;
    public GameHistory AppleGame;
    public GameHistory RPSGame;
    public GameHistory ShooterGame;
    public History()
    {
        logins = new List<string>();
        durations = new List<string>();
    }
}

[Serializable]
public class User
{
    public string username;
    public string password;
    public string status;
    public History history;

    public User(string username, string password, string status)
    {
        this.username = username;
        this.password = password;
        this.status = status;
    }
}

[Serializable]
public class Users
{
    public List<User> users;
    public Users()
    {
        users = new List<User>();
    }
}
