using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float lowerBound = -25f;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {

        //if not game over, then keep moving left
        if (playerControllerScript.gameStart == true && playerControllerScript.gameOver == false )
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //for obstacles 
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}
