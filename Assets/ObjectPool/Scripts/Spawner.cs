using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public float spawnForce = 10f;
    public Vector3 spawnDirection;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
       
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

  
        Rigidbody2D rigidbody = spawnedObject.GetComponent<Rigidbody2D>();

       
        if (rigidbody != null)
        {
           
            rigidbody.AddForce(spawnDirection * spawnForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found on the spawned object. Make sure to attach a Rigidbody.");
        }
    }
}
