using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{

    Rigidbody2D rb;

    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 newVelocity = new Vector2(rb.linearVelocity.x, moveSpeed);

        rb.linearVelocity = newVelocity;
    }
}
