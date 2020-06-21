using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private float speed = 10f;
    public bool projectile = false;
    // Start is called before the first frame update
    void Start()
    {
        if (projectile)
        {
            speed = 30f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
