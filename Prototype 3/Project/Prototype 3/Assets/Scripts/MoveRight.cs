using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Script intented for the player to enter frame and move until start position is reached*/
public class MoveRight : MonoBehaviour
{
    
    private float speed = 2f;
    float startPosition = 4.0f;
    private PlayerController playerControllerScript;
    private ParticleSystem playerDirtParticle;
    private Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        playerDirtParticle = playerControllerScript.dirtParticle;

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameStart)
        {

            if (transform.position.x < startPosition)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else if (transform.position.x >= startPosition)
            {
                Debug.Log("Game Starts Now!");
                playerAnimator.SetTrigger("RunTrigger");
                playerControllerScript.gameStart = true;
                playerDirtParticle.Play();
                
            }
        }

        
    }
}
