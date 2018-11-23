using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    void Start()
    {
        var rb2D = GetComponent<Rigidbody2D>();

        rb2D.velocity = -transform.up * speed;

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
