using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    public Material capMaterial;
    public GameObject gameManagerObj;
    public GameObject leftHand;
    public GameObject rightHand;

    private ActionBasedController xrLeft;
    private ActionBasedController xrRight;

    void Start()
    {
        xrLeft = leftHand.GetComponent<ActionBasedController>();
        xrRight = rightHand.GetComponent<ActionBasedController>();    
    }

    void OnCollisionEnter(Collision col)
    {
        GameObject victim = col.collider.gameObject;

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
                //SceneManager.LoadScene("MainScene");
            }
        }
    }
}
