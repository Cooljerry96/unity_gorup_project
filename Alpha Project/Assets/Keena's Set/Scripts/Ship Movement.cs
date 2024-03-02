using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private bool forwardInput;
    private bool isInputing => forwardInput;
    private float turnInput;
    public float speed = 1f;
    public float turnSpeed = 2f;
    public float forwardDrift = 0.5f;
    public float turnDrift = 1f;
    public Rigidbody rb;


    //  Awake is called when the script is first loaded, or when an object it is attached to is instantiated.
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    private void Update()
    {
        forwardInput = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turnInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turnInput = 1f;
        }
        else
        {
            turnInput = 0f;
        }

        if (forwardInput)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            rb.AddForce(transform.forward * forwardDrift);
        }
        

        if (turnInput != 0f)
        {
            transform.Rotate(Vector3.up * turnInput * turnSpeed);
            rb.AddTorque(transform.up * turnInput * turnDrift);
        }

       
    }
   
}
   