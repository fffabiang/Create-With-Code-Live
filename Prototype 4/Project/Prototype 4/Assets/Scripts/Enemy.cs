﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //enemy should move towards the player
        Vector3 lookDirection = (player.transform.position - transform.position ).normalized;

        //move the player towards the player based off a set speed
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }

    }
}
