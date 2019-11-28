using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCollision : MonoBehaviour
{
    private int caughtShapes;
    public Text scoreText;
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Shape")
        {
            caughtShapes++; 
            //Freeze
            //collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            //Remove the script form the falling object to remove collision errors
            Destroy(collision.gameObject.GetComponent<BouncyScript>());

            scoreText.text = "Score: " + caughtShapes;

        }
    }
}
