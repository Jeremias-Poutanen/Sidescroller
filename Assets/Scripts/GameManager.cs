using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int health = 3;

    public void AddScore()
    {
        score++;
        Debug.Log(score);
    }

    public void TakeDamage()
    {
        health--;

        if(health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }
}
