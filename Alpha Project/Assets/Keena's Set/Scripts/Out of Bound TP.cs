using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutofBoundTP : MonoBehaviour
{
    //Top and bottom Bounds
    private float topBound = 100f;
    private float lowerBound = -100f;

    //Left Right Bounds
    private float rightBound = 100f;
    private float leftBound = -100f;
    //RigidBody Variable
    public Rigidbody rb;

    // Start is called before the first frame update
    private void Awake()
    {
        //makes the RigidBody Constatly run
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Position Variables
        float x = rb.position.x;
        float y = rb.position.y;
        float z = rb.position.z;

        //Teleports
        if (transform.position.z > topBound)
        {
            rb.position = new Vector3(x, y, lowerBound);
        }
        else if (transform.position.z < lowerBound)
        {
            rb.position = new Vector3(x, y, topBound);
        }
        else if (transform.position.x < leftBound)
        {
            rb.position = new Vector3(rightBound, y, z);
        }
        else if (transform.position.x > rightBound)
        {
            rb.position = new Vector3(leftBound, y, z);
        }

    }
}
