using UnityEngine;

public class Magnetize : MonoBehaviour
{

    private Transform currentPlatform = null;



    void Update()

    {

        // Example: Press "E" to magnetize to platform

        if (Input.GetKeyDown(KeyCode.E) && currentPlatform != null)

        {

            transform.SetParent(currentPlatform);

        }



        // Release when key is lifted

        if (Input.GetKeyUp(KeyCode.E))

        {

            transform.SetParent(null);

        }

    }



    void OnCollisionEnter2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Platform"))

        {

            currentPlatform = collision.transform;

        }

    }



    void OnCollisionExit2D(Collision2D collision)

    {

        if (collision.gameObject.CompareTag("Platform"))

        {

            if (currentPlatform == collision.transform)

                currentPlatform = null;

        }

    }

}
