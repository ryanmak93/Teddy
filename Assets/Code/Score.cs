using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;

    public Text cointext;

    // Use this for initialization
    void Start ()
    {
        score = PlayerPrefs.GetInt("coins");
        cointext.text = "Coins: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            updateCoins(10);
        }
    }
    void updateCoins(int change)
    {
        score = PlayerPrefs.GetInt("coins");
        score += change;
        PlayerPrefs.SetInt("coins", score);
        cointext.text = "Coins: " + score.ToString();
    }
}
