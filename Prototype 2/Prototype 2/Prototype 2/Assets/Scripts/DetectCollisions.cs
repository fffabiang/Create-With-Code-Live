using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Text animalCountText;
    private GameObject spawnManager;
    public bool isAnimal = false;
    void Start()
    {
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Spawn Manager");
        animalCountText = GameObject.Find("Animal Count Text").GetComponent<Text>();
    }

    // Update is called once per frame



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("meAnimal:" + isAnimal + " otherAnimal:" + other.gameObject.GetComponent<DetectCollisions>().isAnimal);

        if (isAnimal && other.gameObject.GetComponent<DetectCollisions>().isAnimal)
        {
            Debug.Log("Dos animales en el mismo lugar: eliminando el otro");
            Destroy(other.gameObject);
        }
        else if (!isAnimal && other.gameObject.GetComponent<DetectCollisions>().isAnimal)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            //Animal count text updated when collision detected
            int fedCount = (player.GetComponent<PlayerController>().fedCount += 1);
            animalCountText.text = "Happy animals: " + fedCount;

            //Animal interval decreased every three hits
            if (fedCount % 3 == 0)
            {
                spawnManager.GetComponent<SpawnManager>().UpdateSpawning();
            }

            Debug.Log("Score so far:" + fedCount + " SpawnInterval:" + spawnManager.GetComponent<SpawnManager>().spawnInterval);

        }


    }


}
