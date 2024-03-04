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
        float bottomRange = rb.position.y - 50;
       

        for (int i = 0; i < amountPerSpawn; i++)
        {
      
            // Choose a random direction from the center of the spawner and
            // spawn the asteroid a distance away
            Vector3 spawnDirection = new Vector3(0,0,0);
            vectors[0] = new Vector3(leftRange, 0f , Random.Range(topRange,bottomRange));
            vectors[1] = new Vector3(rightRange, 0f, Random.Range(topRange, bottomRange));
            vectors[2] = new Vector3(Random.Range(leftRange, rightRange), 0f, topRange);
            vectors[3] = new Vector3(Random.Range(leftRange, rightRange), 0f, bottomRange);
            
            // Calculate a random variance in the asteroid's rotation which will
            // cause its trajectory to change
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis( variance, spawnDirection);

            // Create the new asteroid by cloning the prefab and set a random
            // size within the range
            Asteroid asteroid = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], vectors[Random.Range(0,4)], rotation );
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);

            if (asteroid.transform.position == vectors[0])
            {
                asteroid.transform.rotation = new Quaternion(0f, Random.Range(220, 130), 0f, 0f);
            }
            
        }
       
    }

}