using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 newPosition = transform.position;

    if (Input.GetKey("d"))
    {
        newPosition.x += moveSpeed * Time.deltaTime;
    }
   
    if (Input.GetKey("a"))
    {
        newPosition.x -= moveSpeed * Time.deltaTime;
    }
        transform.position = newPosition;
    }
}
