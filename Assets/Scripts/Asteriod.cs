using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{

    public float speed;
    public int pointValue;
    private GameController gameController;
    private AudioSource audioSource;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        var rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = -transform.up * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            if (other.tag == "Player")
            {
                gameController.GameOver();
            }
            gameController.AddScore(pointValue);
            Destroy(other.gameObject);
            Destroy(gameObject, .2f);
        }     
    }
}
