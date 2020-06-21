using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GravityButton : MonoBehaviour
{

    private Button gravityButton;
    private float zerogTime = 3f;
    Vector3 originalGravity;
    private GameManager gameManager;
    public GameObject gravityChangeEffect;

    // Start is called before the first frame update

    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gravityButton = GetComponent<Button>();
        gravityButton.onClick.AddListener(StartZeroG);
        originalGravity = Physics.gravity;
        Debug.Log("currentGravity:" + originalGravity);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.gravityChanged == true)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= zerogTime)
            { 
                timePassed = 0f;
                StopZeroG();
            }

        }

    }

    float timePassed = 0;

    void StopZeroG()
    {
        gameManager.gravityChanged = false;
        Physics.gravity = originalGravity;
        Debug.Log("Gravity restored to " + originalGravity);
        gravityChangeEffect.SetActive(false);
    }

    void StartZeroG()
    {

        if (gameManager.gravityChanged == false)
        {
            gameManager.gravityChanged = true;
            gravityButton.interactable = false;
            gravityChangeEffect.SetActive(true);


            foreach (GameObject gameObj in gameManager.listSpawned)
            {

                if (gameObj != null)
                {
                    gameObj.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
                }

            }
            Physics.gravity = new Vector3(0, -1f, 0);


            Debug.Log("Gravity changed to " + Physics.gravity + " for " + zerogTime + " seconds");
        }

    }

}
