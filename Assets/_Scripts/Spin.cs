using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Rotates the logo to create a smooth animation
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 2f, 0f);
    }
}
