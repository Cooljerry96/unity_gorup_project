using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutofBoundTP : MonoBehaviour
{
    //Top and bottom Bounds
    private float topBound = 800f;
    private float lowerBound = -800f;

    //Left Right Bounds
    private float rightBound = 800f;
    private float leftBound = -800f;

    //RigidBody Variable
    public Rigidbody rb;
    public bool screenWrapping = true;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Call Screen Warp
        if (screenWrapping)
        {
            ScreenWrap();

        }
    }

    //ScreenWarp function
     private void ScreenWrap()
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
