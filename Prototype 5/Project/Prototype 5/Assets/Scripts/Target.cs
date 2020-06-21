using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public float minSpeed = 8f;
    public float maxSpeed = 12f;

    public float xRange = 5.5f;
    private float ySpawnPos = -1f;

    private Rigidbody targetRb;
    private GameManager gameManager;
    float maxTorque = 10f;
    public int pointValue = 1;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomUpwardForce(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse );
        gameManager.listSpawned.Add(gameObject);
        Debug.Log("Added to the gameManager:" + gameObject + " new Size = " + gameManager.listSpawned.Count);


    }

    // Update is called once per frame
    void Update()
    {

    } 

    float RandomTorque()
    {
        float randomTorque = Random.Range(0, maxTorque);
        return randomTorque;
    }

    Vector3 RandomUpwardForce()
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        return Vector3.up * randomSpeed;
    }

    float posSeparation = 1f;
    float maxYforCheking = 3f;
    bool CheckIfBehind(float posX)
    {
        Debug.Log("Checking if posX = " + posX + " is ok..");

        foreach (GameObject gameObj in gameManager.listSpawned)
        {
            if (gameObj!=null && gameObj.transform.position.y <= maxYforCheking && Math.Abs(gameObj.transform.position.x - posX) <= posSeparation)
            {
                return true;
            }
        }

        return false;
    }

    Vector3 RandomSpawnPos()
    {

        bool foundPos = false;
        float randomXPos = 0;
        while (!foundPos)
        {
            randomXPos = Random.Range(-xRange, xRange);
            if (CheckIfBehind (randomXPos) == false)
            {
                Debug.Log("New spawning position for "+ gameObject +" is not behind other spawned objects.. OK");
                foundPos = true;
            }
            else
            {
                Debug.Log("New spawning position for "+ gameObject + "BAD.. will retry.");
            }
        }
        
        return new Vector3(randomXPos, ySpawnPos);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.listSpawned.Remove(gameObject);

            if (gameObject.CompareTag("New Life"))
            {
                gameManager.LifeUp();
            }

            if (gameObject.CompareTag("Gravity Changer"))
            {
                gameManager.gravityButton.interactable = true;
            }

            Destroy(gameObject);
            gameManager.PlayJumpSound();
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //entering an object with a trigger destroy the object without trigger
        
        if (gameObject.CompareTag("New Life") || gameObject.CompareTag("Gravity Changers"))
        {
            return;
        }

        /*If player lost all lives then lose the game, else keep discounting lives*/
        if (gameManager.lives > 1)
        {
            gameManager.LoseLife();
        }
        else if (gameManager.isGameActive)
        {
            gameManager.LoseLife();
            gameManager.GameOver();
        }
    }



}
