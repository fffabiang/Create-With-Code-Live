using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    int maxJumps = 2;
    int numJumps = 0;
    public bool gameOver = false;
    public bool gameStart = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numJumps<maxJumps && !gameOver && gameStart)
        {

            numJumps++;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound);

            //isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.gameObject.CompareTag("Ground") && gameStart)
        {
            //isOnGround = true;
            numJumps = 0;            
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound,1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();

        }

    }

}
