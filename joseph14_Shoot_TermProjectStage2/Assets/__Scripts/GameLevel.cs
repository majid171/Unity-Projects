using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel
{
    public int score;
    public int MaxEnemies;

    public GameLevel(int _score, int _MaxEnemies)
    {
        score = _score;
        MaxEnemies = _MaxEnemies;
    }
}
