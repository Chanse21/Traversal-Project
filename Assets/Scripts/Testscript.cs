using UnityEngine;

public class Testscript : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
    Debug.Log("Collided with: "  + collision.gameObject.name);
   }
}
