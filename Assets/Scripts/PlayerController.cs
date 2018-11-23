using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform Bullet_Spawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, Bullet_Spawn.position, Bullet_Spawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var rb2D = GetComponent<Rigidbody2D>();

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        rb2D.velocity = movement * speed;

        rb2D.position = new Vector3
        (
            Mathf.Clamp(rb2D.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb2D.position.y, boundary.yMin, boundary.yMax)
        );
    }
}