using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 40f;
    public float xRange = 10;
    public Camera camera;
    private float offsetBound = 0;
    public GameObject projectilePrefab;
    public int fedCount = 0;
    public bool gameOver = false;

    Vector3 offsetPosition = new Vector3(0, 1,0);


    // Start is called before the first frame update
    void Start()
    {

        Vector3 p = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));
        Debug.Log(p);
        xRange = Math.Abs(p.x) - offsetBound;
        Debug.Log("xrange = " + xRange);

    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            return;
        }
        
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position+offsetPosition, projectilePrefab.transform.rotation);
        }


    }
}
