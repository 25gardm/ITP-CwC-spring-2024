using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float repeatRate = 2;
    private Vector3 spawnPos;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObjects", spawnDelay, repeatRate);
        playerControllerScript = 
            GameObject.Find("Player").GetComponent<PlayerControllerX>();
        Vector3 spawnPos = new Vector3(30, Random.Range(5, 15), 0);
        
    }

    // Spawn obstacles
    void spawnObjects()
    {
        // Set random spawn location and random object index
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(objectPrefabs[index], spawnPos, objectPrefabs[index].transform.rotation);
        }

    }
}
