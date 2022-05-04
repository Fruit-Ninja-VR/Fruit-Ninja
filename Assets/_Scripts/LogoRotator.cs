using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float speed = 5f;

    private Vector3 randomRotation;


    // Update is called once per frame
    void Update()
    {
       //transform.Rotate(_rotation * speed *Time.deltaTime);
       transform.Rotate(transform.up, speed * Time.deltaTime);
    }

}
