using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{

    public float speed;
    private AudioSource audioSource;
    private GameController gameController;

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
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);

        }
        else if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.GameOver();
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

    }
}
