using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] float speed = 5f;
    GameManager gameManager;
    float width;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        startPosition = transform.position;
        width = GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (!gameManager.gameOver)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if(transform.position.x < startPosition.x - width / 2.0f)
            {
                transform.position = startPosition;
            }
        }
    }
}
