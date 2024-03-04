using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    //public Rigidbody rb;
    [SerializeField]
    private float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;

    }
}