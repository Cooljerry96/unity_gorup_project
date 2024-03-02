using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OutofBoundTP : MonoBehaviour
{
    private float topBound = 3.9f;
    private float lowerBound = -3.9f;
    private float rightBound = 6.9f;
    private float leftBound = -6.9f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        float x = rb.position.x;
        float y = rb.position.y;
        float z = rb.position.z;

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
