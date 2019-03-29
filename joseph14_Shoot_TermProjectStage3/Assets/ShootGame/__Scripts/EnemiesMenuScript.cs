using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemiesMenuScript : MonoBehaviour
{

    public Button exit;
    public Dropdown points0, points1, points2, points3, points4;
    public Dropdown colour0, colour1, colour2, colour3, colour4;
    public Material Mat0, Mat1, Mat2, Mat3, Mat4;
    public Color c1, c2, c3, c4, c5;
    
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(exitClick);
    }

    // Update is called once per frame
    void Update()
    {

        // Switch for colours
        switch (colour0.value)
        {
            case 0:
                Mat0.color = c1;
                break;
            case 1:
                Mat0.color = c2;
                break;
            case 2:
                Mat0.color = c3;
                break;
            case 3:
                Mat0.color = c4;
                break;
            case 4:
                Mat0.color = c5;
                break;
        }

        switch (colour1.value)
        {
            case 0:
                Mat1.color = c1;
                break;
            case 1:
                Mat1.color = c2;
                break;
            case 2:
                Mat1.color = c3;
                break;
            case 3:
                Mat1.color = c4;
                break;
            case 4:
                Mat1.color = c5;
                break;
        }

        switch (colour2.value)
        {
            case 0:
                Mat2.color = c1;
                break;
            case 1:
                Mat2.color = c2;
                break;
            case 2:
                Mat2.color = c3;
                break;
            case 3:
                Mat2.color = c4;
                break;
            case 4:
                Mat2.color = c5;
                break;
        }

        switch (colour3.value)
        {
            case 0:
                Mat3.color = c1;
                break;
            case 1:
                Mat3.color = c2;
                break;
            case 2:
                Mat3.color = c3;
                break;
            case 3:
                Mat3.color = c4;
                break;
            case 4:
                Mat3.color = c5;
                break;
        }

        switch (colour4.value)
        {
            case 0:
                Mat4.color = c1;
                break;
            case 1:
                Mat4.color = c2;
                break;
            case 2:
                Mat4.color = c3;
                break;
            case 3:
                Mat4.color = c4;
                break;
            case 4:
                Mat4.color = c5;
                break;
        }

        // Switch for Score received from each enemy
        switch (points0.value)
        {
            case 0:
                Main.damage0 = 5;
                break;
            case 1:
                Main.damage0 = 10;
                break;
            case 2:
                Main.damage0 = 15;
                break;
            case 3:
                Main.damage0 = 20;
                break;
            case 4:
                Main.damage0 = 25;
                break;
        }

        switch (points1.value)
        {
            case 0:
                Main.damage1 = 5;
                break;
            case 1:
                Main.damage1 = 10;
                break;
            case 2:
                Main.damage1 = 15;
                break;
            case 3:
                Main.damage1 = 20;
                break;
            case 4:
                Main.damage1 = 25;
                break;
        }

        switch (points2.value)
        {
            case 0:
                Main.damage2 = 5;
                break;
            case 1:
                Main.damage2 = 10;
                break;
            case 2:
                Main.damage2 = 15;
                break;
            case 3:
                Main.damage2 = 20;
                break;
            case 4:
                Main.damage2 = 25;
                break;
        }

        switch (points3.value)
        {
            case 0:
                Main.damage3 = 5;
                break;
            case 1:
                Main.damage3 = 10;
                break;
            case 2:
                Main.damage3 = 15;
                break;
            case 3:
                Main.damage3 = 20;
                break;
            case 4:
                Main.damage3 = 25;
                break;
        }

        switch (points4.value)
        {
            case 0:
                Main.damage4 = 5;
                break;
            case 1:
                Main.damage4 = 10;
                break;
            case 2:
                Main.damage4 = 15;
                break;
            case 3:
                Main.damage4 = 20;
                break;
            case 4:
                Main.damage4 = 25;
                break;
        }
    }

    void exitClick()
    {
        SceneManager.LoadScene("ConfigScene");
    }
}
