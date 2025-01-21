using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnEnemy;

    public float frequency;

    public float initialSpeed;

    private float lastSpawnedTime;
    private int spawnCount; // Counter to track the number of spawned items
    public int maxSpawnCount = 10; // Maximum number of items to spawn

    // Update is called once per frame
    void Update()
    {
        if (spawnCount < maxSpawnCount && Time.time > lastSpawnedTime + frequency)
        {
            Spawn();
            lastSpawnedTime = Time.time;
        }
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnEnemy, transform.position, Quaternion.identity);
        newSpawnedObject.GetComponent<Rigidbody>().velocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;

        spawnCount++; // Increment the counter
    }
}
