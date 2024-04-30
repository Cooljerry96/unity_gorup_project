using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public Rigidbody rb;
    public Asteroid[] asteroidPrefab;
    public float spawnDistance = 50f;
    public float spawnRate = 1f;
    public int amountPerSpawn = 1;
    public float trajectoryVariance = 0f;
    private Vector3[] vectors = new Vector3[4];

    //public Transform from;// = new Transform[4];
    //public Transform to;// = new Transform[4];
    //private float timeCount = 0f;
    //private float leftAngle = Random.Range(-0.9239f, 0.9239f);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);

    }
    public void Update()
    {

        
    }

    public void Spawn()
    {
        float leftRange = rb.position.x - 50;
        float rightRange = rb.position.x + 50;
        float topRange = rb.position.z + 50;
        float bottomRange = rb.position.z - 50;


        for (int i = 0; i < amountPerSpawn; i++)
        {

            // Choose a random direction from the center of the spawner and
            // spawn the asteroid a distance away
            Vector3 spawnDirection = new Vector3(0, 0, 0);
            vectors[0] = new Vector3(leftRange, 0f, Random.Range(topRange, bottomRange));
            vectors[1] = new Vector3(rightRange, 0f, Random.Range(topRange, bottomRange));
            vectors[2] = new Vector3(Random.Range(leftRange, rightRange), 0f, topRange);
            vectors[3] = new Vector3(Random.Range(leftRange, rightRange), 0f, bottomRange);

            // Calculate a random variance in the asteroid's rotation which will
            // cause its trajectory to change
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, spawnDirection);

            // Create the new asteroid by cloning the prefab and set a random
            // size within the range
            Asteroid asteroid = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], vectors[Random.Range(0, 4)], rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            if (asteroid.transform.position == vectors[0])
            {
                asteroid.transform.rotation = Quaternion.AngleAxis(Random.Range(45, 135), Vector3.up);
                //asteroid.transform.rotation = new Quaternion(0.0f, Random.value, 0.0f, Random.value);
                //asteroid.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
            }
            if (asteroid.transform.position == vectors[1])
            {
                asteroid.transform.rotation = Quaternion.AngleAxis(Random.Range(-45, -135), Vector3.up);
            }
            if (asteroid.transform.position == vectors[2])
            {
                asteroid.transform.rotation = Quaternion.AngleAxis(Random.Range(145, 215), Vector3.up);
            }
            if (asteroid.transform.position == vectors[3])
            {
                asteroid.transform.rotation = Quaternion.AngleAxis(Random.Range(-45, 45), Vector3.up);
            }
            //if (asteroid.transform.position.x > rightRange + 5)
            //{
                //Destroy(asteroid);
            //}
            //if (asteroid.transform.position.x < leftRange - 5)
            //{
                //Destroy(asteroid);
            //}
            //if (asteroid.transform.position.z > topRange + 5)
            //{
                //Destroy(asteroid);
            //}
            //if (asteroid.transform.position.z < bottomRange - 5)
            //{
                //Destroy(asteroid);
            //}
        }
    }
    }

