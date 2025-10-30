using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour
{

    public float moveSpeed = 5f;

    public bool usePhysics = true; // Set to false if you don't want to use Rigidbody2D



    private Rigidbody2D rb;



    void Start()

    {

        if (usePhysics)

        {

            rb = GetComponent<Rigidbody2D>();

            if (rb == null)

            {

                Debug.LogWarning("Rigidbody2D not found! Switching to transform movement.");

                usePhysics = false;

            }

        }

    }



    void FixedUpdate()

    {

        if (usePhysics)

        {

            // Move with Rigidbody2D velocity

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveSpeed);

        }

        else

        {

            // Move without Rigidbody2D

            transform.position += Vector3.up * moveSpeed * Time.fixedDeltaTime;

        }

    }

}