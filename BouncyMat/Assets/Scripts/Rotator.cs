using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float y_angle = 0;
    public float x_angle = 0;
    public float z_angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        x_angle = Random.Range(-2.0f, 2.0f);
        z_angle = Random.Range(-2.0f, 2.0f);
        y_angle = Random.Range(-2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x_angle, y_angle, z_angle);
    }
}
