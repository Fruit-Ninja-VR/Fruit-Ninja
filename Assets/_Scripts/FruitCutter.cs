using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody))]
public class FruitCutter : MonoBehaviour
{   
    public Material capMaterial;
    public GameObject gameManagerObj;

    private GameManager gameManager;
    
    void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject victim = collision.collider.gameObject;

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
                gameManager.Bombed();
                break;


        }

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if(!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
            pieces[1].AddComponent<Fruit>();
            MeshCollider temp = pieces[1].AddComponent<MeshCollider>();
            temp.convex = true;
        }
            
        //Destroy(pieces[1], 1);
    }
}
