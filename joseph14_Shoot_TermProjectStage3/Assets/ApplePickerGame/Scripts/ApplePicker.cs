using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // b
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] // a
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    public Button exit;
    public static System.DateTime initial;


    void Start()
    {
        initial = System.DateTime.Now;

        exit.onClick.AddListener(delegate {
            GameComplete();
            SceneManager.LoadScene("GameMenu");
        });

        basketList = new List<GameObject>(); // c
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO); // d
        }
    }

    public void AppleDestroyed()
    { // a
      // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // b
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Destroy one of the baskets // e
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject tBasketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        // If there are no Baskets left, restart the game
        if (basketList.Count == 0)
        {
            GameComplete();
            SceneManager.LoadScene("_Scene_0_Apple"); // a
        }
    }

    public void GameComplete()
    {
        Login.auth.users[Login.UserIndex].history.AppleGame.dates.Add(initial.ToString("yyyy/MM/dd HH:mm:ss"));
        Login.auth.users[Login.UserIndex].history.AppleGame.scores.Add(Basket.scoreGT.text);
        Login.WriteData();
    }
}
