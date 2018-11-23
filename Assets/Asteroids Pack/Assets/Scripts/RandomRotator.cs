using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
     public float tumble;

    void Start()
    {
        var rb2D = GetComponent<Rigidbody2D>();
        rb2D.angularVelocity = Random.value * tumble;
    }
}