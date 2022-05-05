using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent (typeof(Rigidbody))]
public class FruitCutter : MonoBehaviour
{   
    public Material capMaterial;
    public GameObject gameManagerObj;
    public GameObject leftHand;
    public GameObject rightHand;

    private GameManager gameManager;
    private ActionBasedController xrLeft;
    private ActionBasedController xrRight;
    
    void Start()
    {
        //gameManager = gameManagerObj.GetComponent<GameManager>();
        xrLeft = leftHand.GetComponent<ActionBasedController>();
        xrRight = rightHand.GetComponent<ActionBasedController>();
        Debug.Log("Get controller");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        GameObject victim = collision.collider.gameObject;

        if(victim.name != "left side" || victim.name != "right side") {
            Fruit fruit = victim.GetComponent<Fruit>();
            // Check if this fruit or bomb was already hit
            if(fruit.WasHit() == false) {
                // If it wasn't hit before, now it is
                fruit.GotHit(true);
                switch (victim.tag)
                {
                    case "Small":
                        gameManager.SetScore(50);
                        break;
                    case "Medium":
                        gameManager.SetScore(25);
                        break;
                    case "Large":
                        gameManager.SetScore(10);
                        break;
                    case "Bomb":
                        // Vibrate both controllers for explosion
                        xrLeft.SendHapticImpulse(1f, 0.8f);
                        xrRight.SendHapticImpulse(1f, 0.8f);
                        // Freeze bomb
                        victim.GetComponent<Rigidbody>().isKinematic = true;
                        // Explode bomb
                        victim.GetComponent<BombController>().explode();
                        // Lose Life
                        gameManager.Bombed();
                        // Destroy bomb after 0.3 seconds
                        Destroy(victim, 0.3f);
                        break;
                }

                // Vibrate a controller when it hits a fruit
                if(this.tag == "Left") {
                    xrLeft.SendHapticImpulse(0.5f, 0.5f);
                } else if(this.tag == "Right") {
                    xrRight.SendHapticImpulse(0.5f, 0.5f);
                }
            }

            if(victim.tag != "Bomb") {
                // Cut fruit
                GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                if(!pieces[1].GetComponent<Rigidbody>())
                {
                    pieces[1].AddComponent<Rigidbody>();
                    pieces[1].AddComponent<Fruit>();
                    MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
                    temp.convex = true;
                }
                
                // When hitting the same fruit multiple times, add a minor vibration
                if(this.tag == "Left") {
                    xrLeft.SendHapticImpulse(0.3f, 0.2f);
                } else if(this.tag == "Right") {
                    xrRight.SendHapticImpulse(0.3f, 0.2f);
                }
            }
        }
    }
}
