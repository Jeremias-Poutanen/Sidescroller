using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;
    int score = 0;
    int health = 3;

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        Debug.Log(score);
    }

    public void TakeDamage()
    {
        health--;
        healthText.text = health.ToString();

        if(health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
