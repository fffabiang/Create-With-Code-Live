using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    private float rotationAngle = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //Ubicar la camara a una distancia offset definida del objeto
        transform.position = player.transform.TransformPoint(offset);
        //Rotar la camara junto con el objeto
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {



    }
}
