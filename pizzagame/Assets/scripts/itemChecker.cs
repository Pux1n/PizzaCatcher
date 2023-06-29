using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class itemChecker : MonoBehaviour
{

    public static int score = 0;
    public Text scoreText;
    public static int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        score = 0;
        health = 3;
    }

    void Update()
    {
        if (ItemSpawn.gameOver)
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Good")
        {
            score = score + 1;
            ScoreBanking.scoreBank = ScoreBanking.scoreBank + 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Bad")
        {
            health--;
            Destroy(other.gameObject);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        scoreText.text = score.ToString();
    }
}