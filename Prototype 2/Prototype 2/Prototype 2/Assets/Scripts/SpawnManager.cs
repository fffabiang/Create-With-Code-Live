using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;
    public int animalIndex;
    private float spawnRangeX = 15;
    private float spawnPosZ = 25;
    private Vector3 spawnPosition;
    private float startDelay = 2f;
    public float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        //Prefab to instantiate, position, rotation of prefab
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    public void UpdateSpawning()
    {
        if (spawnInterval >= 0.2f)
        {
            spawnInterval -= 0.1f;
            CancelInvoke("SpawnRandomAnimal");
            InvokeRepeating("SpawnRandomAnimal", 0, spawnInterval);

        }
            
    }

}
