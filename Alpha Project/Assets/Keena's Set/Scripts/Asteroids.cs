using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Asteroid : MonoBehaviour
{
   
    public Rigidbody rb;

    [SerializeField]

    public GameObject player;
    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;
    public float movementSpeed = .25f;
    public float maxLifetime = 30f;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        
        
        // Set the scale and mass of the GameObject based on the assigned size so
        // the physics is more realistic
        transform.localScale = Vector3.one * size;
        rb.mass = size;

        
       
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed);

        if (this.transform.position.x > player.transform.position.x + 110)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.x < player.transform.position.x - 110)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.z > player.transform.position.z + 110)
        {
            Destroy(gameObject);
        }
        if (this.transform.position.z < player.transform.position.z - 110)
        {
            Destroy(gameObject);
        }
        
        
    }
    public void SetTrajectory(Vector3 direction)
    {
        // The GameObject only needs a force to be added once since they have no
        // drag to make them stop moving
        rb.AddForce( direction * movementSpeed);
    }

}