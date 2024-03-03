using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{ // Basic movement
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public float verticalInput;
    public float horizontalInput;

 // Drifting movement
    public float drift = 1.0f;
    public float vertDrift;
    public float horizDrift;
    private Rigidbody rigidbodies;
    

 

    /*
    public float speed = 40.0f;
    public float turnSpeed = 40.0f;
    
    public float verticalInput; */

    private void Awake()
    {
        rigidbodies = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // Forward Movement key accept
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * thrustSpeed * Time.deltaTime);

        //  Left  and Right key accept
       horizontalInput = Input.GetAxis("Horizontal");
       transform.Rotate(Vector3.up  * horizontalInput * turnSpeed * Time.deltaTime);



        // forward movement sliding

      





    }
    private void FixedUpdate()
    {

        if (verticalInput != 0)
        {
            rigidbodies.AddForce(this.transform.forward * (this.verticalInput +  drift) * thrustSpeed);
        }


        // turn direction sliding 
        if (horizontalInput != 0)
        {
            rigidbodies.AddTorque(this.transform.up *  (this.horizontalInput + (drift * horizontalInput)) * turnSpeed);
        }



    }
}

