using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    public float parrallax = 2f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector3 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parrallax;
        offset.y = transform.position.z / transform.localScale.z / parrallax;
      //  offset.z = transform.position.z / transform.localScale.z;

        mat.mainTextureOffset = offset;
    }
}