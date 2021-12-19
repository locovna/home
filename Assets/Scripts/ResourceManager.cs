using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public GameObject resource;
    public List<GameObject> resources = new List<GameObject>();
    float xPosition;
    float yPosition = 0.5f;
    float zPosition;

    void Start()
    {

    }

    void Update()
    {
        SpawnResource(resource);
        // Debug.Log("Total spawned resources: " + resources.Count);
    }

    void SpawnResource(GameObject resourceToSpawn)
    {
        xPosition = Random.Range(-40, 40);
        zPosition = Random.Range(-40, 40);
        Instantiate(resourceToSpawn, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
        resources.Add(resourceToSpawn);
    }
}
