using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCollision : MonoBehaviour
{
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            Debug.Log(collision.gameObject.name + " entered");
            collision.gameObject.transform.SetParent(transform);
            //If the GameObject has the same tag as specified, output this message in the console
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " exited");
        collision.gameObject.transform.SetParent(null);
        
    }
}
