using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{

    Rigidbody rb;
    Vector3 angle;
    public float force = 1;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private float delay = 0;

    void Update()
    {
        delay = delay - Time.deltaTime;
    }

    void OnCollisionStay(Collision collision)
    {
        if (delay <= 0 && collision.gameObject.tag == "particle")
        {
            delay = 1;

            //Current speed of the object
            Vector3 thisVelocity = transform.GetComponent<Rigidbody>().velocity;
            float thisVelocity_x = (thisVelocity.normalized).x;
            float thisVelocity_z = (thisVelocity.normalized).z;

            //Current speed of the bouncy mat
            Vector3 matVelocity = collision.transform.GetComponent<Rigidbody>().velocity;
            float matVelocity_x = (matVelocity.normalized).x;
            float matVelocity_z = (matVelocity.normalized).z;

            //Add that force
            rb.AddForce(new Vector3(matVelocity_x, 1, matVelocity_z) * force * 150);
        }

        // Should be closer to the actual relative velocity but does not provide desired behaviour.
        // if (delay <= 0 && collision.gameObject.tag == "particle")
        // {
        //     delay = 1;

        //     //Current speed of the object
        //     Vector3 thisVelocity = transform.GetComponent<Rigidbody>().velocity;
        //     float thisVelocity_x = (thisVelocity.normalized).x;
        //     float thisVelocity_z = (thisVelocity.normalized).z;
        //     Vector3 shapeVelocity = new Vector3(thisVelocity_x, 0, thisVelocity_z);

        //     //Current speed of the bouncy mat
        //     Vector3 matVelocity = collision.transform.GetComponent<Rigidbody>().velocity;
        //     float matVelocity_x = (matVelocity.normalized).x;
        //     float matVelocity_z = (matVelocity.normalized).z;
        //     Vector3 bouncyMatVelocity = new Vector3(matVelocity_x, 1, matVelocity_z);

        //     Vector3 relativeSpeed = bouncyMatVelocity - shapeVelocity;

        //     //Add that force
        //     rb.AddForce(relativeSpeed * force * 150);
        // }

    }
}
