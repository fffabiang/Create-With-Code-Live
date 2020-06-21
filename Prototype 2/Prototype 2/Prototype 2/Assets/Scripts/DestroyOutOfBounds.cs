using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 50f;
    private float lowerBound = -5f;
    private float leftBound = -20f;
    private float rightBound = 20f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < leftBound)
        {

        }else if (transform.position.x > rightBound)
        {

        }else if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }else if (transform.position.z < lowerBound)
        {
            //This is an animal since its lower bound
            Destroy(gameObject);

            //We decrease one life from the player when animal hits lower bound
            punishPlayer();

        }

    }

    void punishPlayer()
    {
        GameObject lifeCounter = GameObject.Find("LifeCounter");
        lifeCounter.GetComponent<LifeCounter>().decreaseLife();

    }



}
