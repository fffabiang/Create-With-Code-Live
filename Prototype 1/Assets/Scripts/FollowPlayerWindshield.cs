using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerWindshield : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = player.transform.TransformPoint(offset);
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }
}
