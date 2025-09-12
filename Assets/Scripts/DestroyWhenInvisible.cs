using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DestroyWhenInvisible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
