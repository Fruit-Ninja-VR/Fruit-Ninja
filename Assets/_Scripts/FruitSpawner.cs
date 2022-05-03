using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruit;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while(true) 
        {
            // Get the amount of fruit to be spawned
            int rand = Random.Range(0, spawners.Length / 2);

            for(int i = 0; i < rand; i++) {
                GameObject go = Instantiate(fruit[Random.Range(0, fruit.Length)]);
                Rigidbody temp = go.GetComponent<Rigidbody>();

                if(temp.tag == "Bomb") {
                    temp.velocity = new Vector3(0f, 7f, 7f);
                    temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                } else {
                    temp.velocity = new Vector3(0f, 9f, 11f);
                    temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
                }
                temp.useGravity = true;

                Vector3 pos = transform.position;
                pos.x += Random.Range(-1f, 1f);
                go.transform.position = pos;
            }

            yield return new WaitForSeconds(1f);    
        }
    }

    /*IEnumerator SpawnFruit()
    {
        while(true) 
        {
            GameObject go = Instantiate(fruit[Random.Range(0, fruit.Length)]);
            Rigidbody temp = go.GetComponent<Rigidbody>();

            if(temp.tag == "Bomb") {
                temp.velocity = new Vector3(0f, 7f, 7f);
                temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            } else {
                temp.velocity = new Vector3(0f, 9f, 11f);
                temp.angularVelocity = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
            }
            temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-1f, 1f);
            go.transform.position = pos;

            yield return new WaitForSeconds(1f);    
        }
    }*/
}
