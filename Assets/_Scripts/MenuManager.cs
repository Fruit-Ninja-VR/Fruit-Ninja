using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Material capMaterial;
    public GameObject rightHand;
    private ActionBasedController xrRight;

    void Start()
    {
        xrRight = rightHand.GetComponent<ActionBasedController>();    
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision");
        GameObject victim = col.collider.gameObject;

        if(victim.name != "left side" || victim.name != "right side") {
            Fruit fruit = victim.GetComponent<Fruit>();
            // Check if this fruit or bomb was already hit
            if(fruit.WasHit() == false) {
                // If it wasn't hit before, now it is
                fruit.GotHit(true);
                xrRight.SendHapticImpulse(0.5f, 0.5f);
                switch(victim.tag)
                {
                    case "Start":
                        StartCoroutine(StartGame());
                        break;
                    case "Restart":
                        StartCoroutine(StartGame());
                        break;
                    case "Exit":
                        StartCoroutine(ExitGame());
                        break;
                }
            }
        } else {
            // When hitting the same fruit multiple times, add a minor vibration
            xrRight.SendHapticImpulse(0.3f, 0.2f);
        }

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if(!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
            pieces[1].AddComponent<Fruit>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        // load new scene once watermelon is sliced
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(0.5f);
        // load new scene once watermelon is sliced
        SceneManager.LoadScene("MainMenu");
    }
}
