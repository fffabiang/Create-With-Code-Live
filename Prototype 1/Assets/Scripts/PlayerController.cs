using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    //Camera selection
    public GameObject windshieldCamera;
    public GameObject backCamera;
    bool camSwitch = false;

    // Update is called once per frame
    private float speed = 20.0f;
    private float turnSpeed = 40f;
    private float horizontalInput;
    private float forwardInput;

    void Update()
    {
        //Move the vehicle forward
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        //Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        
  
    }

    private void FixedUpdate()
    {

    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camSwitch = !camSwitch;
            windshieldCamera.SetActive(camSwitch);
            backCamera.SetActive(!camSwitch);

            Debug.Log("Camera changed");
        }


    }

}
