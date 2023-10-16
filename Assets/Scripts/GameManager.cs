using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject harderText;
    [SerializeField] PlayerController playerController;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    public bool gameOver = false;
    int score = 0;
    int health = 3;

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        
        // Every 5 score gained will decrease current obstacle spawn speed by 10%
        if(score % 5 == 0)
        {
            harderText.SetActive(true);
            obstacleSpawner.minSpawnSpeed *= 0.9f;
            obstacleSpawner.maxSpawnSpeed *= 0.9f;
            Invoke("DisableHarderText", 1.5f);
        }
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
        gameOver = true;
        playerController.rb.velocity = Vector3.zero;
        playerController.playerAnimator.SetBool("Death_b", true);
        playerController.playerAnimator.SetInteger("DeathType_int", 1);
        Invoke("GameOverDelay", 2f);
    }
    void GameOverDelay()
    {
        gameOverScreen.SetActive(true);
    }

    void DisableHarderText()
    {
        harderText.SetActive(false);
    }
}
