using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private bool isGrounded = false;
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

    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
          rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }  

   void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }
}

   void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
    }
  }
}