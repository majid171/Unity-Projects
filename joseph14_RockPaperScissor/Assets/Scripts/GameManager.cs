using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private int playerChoose = -1, botChoose = -1, count = 0, winCount = 0;
    private bool playersTurn = true;
    public GameObject WinnerText, CountText, WinCountText, botChooseImage;
    public Sprite paperImage, rockImage, scissorsImage;

    void start()
    {
        // Empty
    }

    // Update is called once per frame
    void Update () {
        if (playersTurn && playerChoose == -1)
            return;
        BotChoose();
        CheckWinner();
        playerChoose = -1;
        playersTurn = true;
        if (count == 10) reset();
	}

    void CheckWinner()
    {
        if(playerChoose == botChoose)
        {
            //draw
            WinnerText.GetComponent<Text>().text = "DRAW!";
        }
        else if ((playerChoose == 1 && botChoose == 3) || (playerChoose == 2 && botChoose == 1) || (playerChoose == 3 && botChoose == 2))
        {
            //player wins
            WinnerText.GetComponent<Text>().text = "YOU WIN!";
            winCount++;
            WinCountText.GetComponent<Text>().text = "Wins: " + winCount;
        }
        else
        {
            //player loses
            WinnerText.GetComponent<Text>().text = "YOU LOSE!";
        }
        count++;
        CountText.GetComponent<Text>().text = "Games Played: " + count;
    }

    public void PlayerChoose(int choose)
    {
        playerChoose = choose;
        playersTurn = false;    //now bot's turn
    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 4); // [min, max)

        if (botChoose == 1)
        {
            botChooseImage.GetComponent<Image>().sprite = rockImage;
        }
        else if (botChoose == 2)
        {
            botChooseImage.GetComponent<Image>().sprite = paperImage;
        }
        else
        {
            botChooseImage.GetComponent<Image>().sprite = scissorsImage;
        }
    }

    void reset()
    {
        SceneManager.LoadScene("Scene0");       
    }
}
