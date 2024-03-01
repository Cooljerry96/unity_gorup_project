using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float forwardInput;
    public float turnInput;
    public float speed = 0f;
    public float turnSpeed = 0f;
    public float drift = 0.3f;
    public float constantSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Mathf.Clamp(Input.GetAxis("Vertical"),0,1);
        turnInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * Time.deltaTime * constantSpeed);
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * turnInput * Time.deltaTime * turnSpeed);

        
    }
}
