using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] float speed = 5f;
    float width;

    void Start()
    {
        startPosition = transform.position;
        width = GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < startPosition.x - width / 2.0f)
        {
            transform.position = startPosition;
        }
    }
}
