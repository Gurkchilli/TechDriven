using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyMats : MonoBehaviour
{
    
    Mesh mesh;
    Vector3[] vertices;
    public GameObject particle;
    GameObject[] particles;
    public Transform particle_parent;

    public float thresh = 1.0f;
    public float input_force = 1.0f;

    public string up;
    public string down;
    public string left;
    public string right;

    void AddSpring(int i, int j)
    {
        SpringJoint sj = particles[i].AddComponent<SpringJoint>() as SpringJoint;
        sj.connectedBody = particles[j].GetComponent<Rigidbody>();
        sj.spring = 50;
        sj.damper = 0.75f;
        sj.autoConfigureConnectedAnchor = true;
    }

    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        vertices = mesh.vertices;
        particles = new GameObject[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 pos = vertices[i];
            GameObject go = Instantiate<GameObject>(particle, transform.TransformPoint(pos), Quaternion.identity);
            go.name = "Particle: " + i;

            if (i == 31 || i == 33 || i == 39 || i == 41 || i == 43 || i == 49 || i == 51 || i == 54 || i == 55 || i == 59 || i == 60 || i == 67 || i == 69 || i == 105 || i == 106 || i == 108 || i == 109 || i == 115 || i == 118 || i == 119 || i == 124 || i == 125 || i == 130 || i == 135 || i == 137)
            {
                Rigidbody rb = go.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezePositionY;
                rb.useGravity = false;
            }

            go.transform.SetParent(particle_parent);

            particles[i] = go;
        }

        for (int i = 0; i < particles.Length; i++)
        {
            Vector3 pos_i = particles[i].transform.position;

            for (int j = 0; j < particles.Length; j++)
            {
                if (i == j) continue;
                Vector3 pos_j = particles[j].transform.position;
                float distance = (pos_i - pos_j).magnitude;

                if (distance < thresh)
                {
                    AddSpring(i, j);
                }

            }
        }

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    //Fixed update makes the movement less dependant on framerate
    void FixedUpdate()
    {

        if (Input.GetKey(left))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(-input_force, 0, 0);

        if (Input.GetKey(right))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(input_force, 0, 0);

        if (Input.GetKey(up))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(0, 0, input_force);

        if (Input.GetKey(down))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(0, 0, -input_force);

        
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 pos = particles[i].transform.position;
            vertices[i] = pos;
        }
        
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        
    }

}
