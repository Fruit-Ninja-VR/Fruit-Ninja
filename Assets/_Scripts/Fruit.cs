using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{ 
    bool hit = false;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10f)
            Destroy(this.gameObject);
    }

    public void GotHit(bool gotHit) 
    {
        this.hit = gotHit;
    }

    public bool WasHit()
    {
        return this.hit;
    }
}
