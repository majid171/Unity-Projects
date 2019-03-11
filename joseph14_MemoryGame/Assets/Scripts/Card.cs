using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public int value;
    public Texture Front;
    public Texture Back;
    public bool isFlipped;
    private GameScene Game;
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
        Game = mainCamera.GetComponent<GameScene>();
        GetComponent<Renderer>().material.mainTexture = Back;
    }

    public void OnMouseDown()
    {
        if (Game.canSelect)
        {
            GetComponent<Renderer>().material.mainTexture = Front;
            SelectCard();
        }
    }

    public void SelectCard()
    {
        if (!isFlipped)
        {
            Game.cardClicked(gameObject);
            isFlipped = true;
        }
    }

    public void reset()
    {
        GetComponent<Renderer>().material.mainTexture = Back;
        isFlipped = false;
    }
}
