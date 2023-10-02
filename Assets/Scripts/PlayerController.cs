using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce = 9f;
    [SerializeField] float gravityMultiplier = 2f;
    [SerializeField] GameManager gameManager;
    bool isOnGround = true;

    private void Start()
    {
        Physics.gravity *= gravityMultiplier; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isOnGround = true;
            return;
        }

        if (collision.collider.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            gameManager.TakeDamage();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameManager.AddScore();
        }
    }
}
