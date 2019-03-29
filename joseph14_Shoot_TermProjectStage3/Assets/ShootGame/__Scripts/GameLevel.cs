using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel
{
    public int score;
    public int MaxEnemies;
    public bool[] arr;

    public GameLevel(int _score, int _MaxEnemies, bool []_arr)
    {
        score = _score;
        MaxEnemies = _MaxEnemies;
        arr = _arr;
    }
}
