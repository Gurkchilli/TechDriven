using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    public float input_force = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-input_force, 0,0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(input_force, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0, 0, input_force);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0, 0, -input_force);
    }
}
