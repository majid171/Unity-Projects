using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{

    private float timer; // Used for formatting

    public static float totalTime;
    public static int score;
    public static int numberOfCards = 12;
    public static int numberOfUniqueCards;
    public static System.DateTime initial;

    public static AudioSource[] sounds;

    public Text scoreText;
    public Text timeText;

    public GameObject cardPrefab;
    public GameObject[] cards;
    public GameObject[] cardsClicked;
    public Texture[] cardFronts;

    private bool isPlaying;
    private int cardsPlayed = 0;
    public bool canSelect = true;

    // Start is called before the first frame update
    void Start()
    {
        score = 1000;
        timer = 0;
        isPlaying = true;
        cardsClicked = new GameObject[2];
        sounds = GetComponents<AudioSource>();
        totalTime = 0;
        StopAllSounds();
        initial = System.DateTime.Now;

        float rowCount = 4.5f;  
        float zPos = 0.9f;      
        float xPos = -6;     
        for (int i = 1; i <= numberOfCards; i++)
        {
            GameObject cardClone = Instantiate(cardPrefab, new Vector3(xPos + (i % 5) * 2f, rowCount, zPos), Quaternion.identity);
            cardClone.GetComponent<Card>().mainCamera = gameObject; //Set the cards mainCamera element so it can reference later

            if (i % 5 == 0)
            {
                rowCount -= 2.7f;   //Delta Y between each row
            }
        }

        Shuffle(); // To shuffle the deck of cards
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            totalTime += Time.deltaTime;
        }
        //Once 2 cards are selected compare them
        if (cardsPlayed == 2 && isPlaying)
        {
            canSelect = false;
            compareCards();
        }
        else
        {
            canSelect = true;
        }

        if (isPlaying)
        {
            scoreText.GetComponent<Text>().text = "Score: " + score;
            timeText.GetComponent<Text>().text = "Time Elapsed: " + totalTime.ToString("F0");

        }

        if (GameObject.FindGameObjectsWithTag("Card").Length == 0)
        {
            isPlaying = false;
            Login.auth.users[Login.UserIndex].history.MemoryGame.scores.Add(GameScene.score + "");
            Login.auth.users[Login.UserIndex].history.MemoryGame.dates.Add(initial.ToString("yyyy/MM/dd HH:mm:ss"));
            Login.WriteData();
            SceneManager.LoadScene("WinMemory");
        }

        if (score <= 0)
        {
            isPlaying = false;
            Login.auth.users[Login.UserIndex].history.MemoryGame.scores.Add("0");
            Login.auth.users[Login.UserIndex].history.MemoryGame.dates.Add(initial.ToString("yyyy/MM/dd HH:mm:ss"));
            Login.WriteData();
            SceneManager.LoadScene("LoseMemory");
        }
    }

    public void cardClicked(GameObject card)
    {
        PlaySound(2);
        if (cardsPlayed < 2)
        {
            cardsClicked[cardsPlayed++] = card;
        }
    }

    // To compare two cards
    public void compareCards()
    {
        Card first = cardsClicked[0].GetComponent<Card>();
        Card second = cardsClicked[1].GetComponent<Card>();

        if (first.value == second.value) // The cards match
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                PlaySound(0);

                // Destroy the matched pair
                Destroy(cardsClicked[0], 1f);
                Destroy(cardsClicked[1], 1f);
                cardsPlayed = 0;
                timer = 0;
            }
            
        }
        else // The cards do not match
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                PlaySound(1);
                cardsClicked[0].GetComponent<Card>().reset();
                cardsClicked[1].GetComponent<Card>().reset();
                timer = 0;
                score -= 40;
                cardsPlayed = 0;
            }
        }
    }

    // Function to shuffle the deck of cards
    void Shuffle()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");  //Get every card on the scene
        bool[] hasMaterial = new bool[numberOfCards];       //Array to hold if the card face has been set
        int cardIndex;
        numberOfUniqueCards = numberOfCards / 2;

        //Iterate through the total number of cards
        for (int i = 0; i < numberOfCards; i++)
        {
            cardIndex = Random.Range(0, numberOfCards); 
            while (hasMaterial[cardIndex])
            {
                cardIndex = Random.Range(0, numberOfCards); 
            }
            cards[cardIndex].GetComponent<Card>().Front = cardFronts[i % numberOfUniqueCards]; // Flip card
            cards[cardIndex].GetComponent<Card>().value = i % numberOfUniqueCards; // Set value
            hasMaterial[cardIndex] = true;  
        }
    }


    // Function to play sounds from sound array
    void PlaySound(int index)
    {
        StopAllSounds();
        sounds[index].Play();
    }

    // Function to stop all sounds from sound array
    void StopAllSounds()
    {
        // Stop all other sounds that might be playing
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Stop();
        }
    }




}
