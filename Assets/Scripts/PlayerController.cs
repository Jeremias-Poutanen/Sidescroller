using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float jumpForce = 9f;
    [SerializeField] float gravityMultiplier = 2f;
    [SerializeField] ParticleSystem runningParticles;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject collisionParticle;
    [SerializeField] AudioClip jumpAudio;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip scoreAudio;
    [SerializeField] AudioSource audioSource;
    public Animator playerAnimator;
    bool isOnGround = false;

    private void Start()
    {
        Physics.gravity = new Vector2(0, -9.81f);
        Physics.gravity *= gravityMultiplier; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameManager.gameOver) 
        { 
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            runningParticles.Stop();
            playerAnimator.SetTrigger("Jump_trig");
            audioSource.clip = jumpAudio;
            audioSource.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isOnGround = true;
            if(!gameManager.gameOver)
            {
                runningParticles.Play();
            }
            return;
        }

        if (collision.collider.tag == "Obstacle")
        {
            Instantiate(collisionParticle, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            gameManager.TakeDamage();
            audioSource.clip = crashAudio;
            audioSource.Play();

            if (gameManager.gameOver)
            {
                runningParticles.Stop();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            gameManager.AddScore();
            audioSource.clip = scoreAudio;
            audioSource.Play();
        }
    }
}
