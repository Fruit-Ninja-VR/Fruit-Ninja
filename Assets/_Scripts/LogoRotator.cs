using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoRotator : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       //transform.Rotate(_rotation * speed *Time.deltaTime);
       //transform.Rotate(transform.up, speed * Time.deltaTime);
    }

}
