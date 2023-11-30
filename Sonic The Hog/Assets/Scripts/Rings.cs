using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    public int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            RingCounter.instance.AddRing(value);
        }
    }

}
