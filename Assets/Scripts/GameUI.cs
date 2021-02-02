using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public int health;
    public int numberofmissiles;
    public Text bruh;
    public Text Score;
    int scoreUi;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        health = GameObject.Find("Player").GetComponent<PlayerControls>().health;
        numberofmissiles = GameObject.Find("Player").GetComponent<PlayerControls>().missiles;
        bruh.text = numberofmissiles.ToString();
        Score.text = "Score: " + FindObjectOfType<GameManager>().score.ToString();
        if (health == 1)
        {
            heart1.enabled = true;
            heart2.enabled = false;
            heart3.enabled = false;


        }
        if (health == 2)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = false;

        }
        if (health == 3)
        {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;

        }
        if (health == 0)
        {
            heart1.enabled = false;
            heart2.enabled = false;
            heart3.enabled = false;

        }
    }
}
