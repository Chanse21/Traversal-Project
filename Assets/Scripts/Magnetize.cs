using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Magnetize : MonoBehaviour
{

    private Rigidbody2D rb;



    [Header("Magnet Settings")]

    public float pullForce = 15f;

    public float maxPullSpeed = 10f;

    public float attachDistance = 0.5f;



    private bool isMagnetized = false;

    private Transform currentMagnet = null;

    private List<Transform> nearbyMagnets = new List<Transform>();



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // If E is held, magnetize toward the nearest magnet

        if (Input.GetKey(KeyCode.E))

        {

            if (nearbyMagnets.Count > 0)

            {

                currentMagnet = GetClosestMagnet();



                if (currentMagnet != null)

                    MagnetPull();

            }

        }

        else if (Input.GetKeyUp(KeyCode.E))

        {

            DetachFromMagnet();

        }

    }



    Transform GetClosestMagnet()

    {

        Transform closest = null;

        float minDist = Mathf.Infinity;



        foreach (Transform magnet in nearbyMagnets)

        {

            if (magnet == null) continue;

            float dist = Vector2.Distance(transform.position, magnet.position);

            if (dist < minDist)

            {

                minDist = dist;

                closest = magnet;

            }

        }

        return closest;

    }



    void MagnetPull()

    {

        if (currentMagnet == null) return;



        Vector2 direction = (currentMagnet.position - transform.position);

        float distance = direction.magnitude;



        if (distance > attachDistance)

        {

            Vector2 pull = direction.normalized * pullForce;

            rb.AddForce(pull);

            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxPullSpeed);

        }

        else

        {

            AttachToMagnet();

        }

    }



    void AttachToMagnet()

    {

        if (isMagnetized) return;



        isMagnetized = true;

        rb.linearVelocity = Vector2.zero;

        rb.isKinematic = true;

        transform.SetParent(currentMagnet);

        Debug.Log("Player attached to " + currentMagnet.name);

    }



    void DetachFromMagnet()

    {

        if (!isMagnetized) return;



        isMagnetized = false;

        rb.isKinematic = false;

        transform.SetParent(null);

        Debug.Log("Player detached from " + currentMagnet.name);

    }



    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.CompareTag("Platform"))

        {

            if (!nearbyMagnets.Contains(collision.transform))

                nearbyMagnets.Add(collision.transform);



            Debug.Log("Entered magnet zone: " + collision.name);

        }

    }



    private void OnTriggerExit2D(Collider2D collision)

    {

        if (collision.CompareTag("Platform"))

        {

            nearbyMagnets.Remove(collision.transform);



            if (currentMagnet == collision.transform)

                currentMagnet = null;



            Debug.Log("Exited magnet zone: " + collision.name);

        }

    }

}