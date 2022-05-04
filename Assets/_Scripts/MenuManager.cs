using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        xrLeft = leftHand.GetComponent<ActionBasedController>();
        xrRight = rightHand.GetComponent<ActionBasedController>();    
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject victim = collision.collider.gameObject;

        if(victim.name != "left side" || victim.name != "right side") {
            Fruit fruit = victim.GetComponent<Fruit>();
            // Check if this fruit or bomb was already hit
            if(fruit.WasHit() == false) {
                // If it wasn't hit before, now it is
                fruit.GotHit(true);
            }
            if(victim.tag == "Large")
            {
                // load new scene once watermelon is sliced
            }
        }
    }
}
