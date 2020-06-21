using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    int numLives = 3;
    private Text gameOverText;

    void Start()
    {
        gameOverText = GameObject.Find("Game Over Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void decreaseLife()
    {
        
        if (numLives > 0)
        {
            numLives--;
            if (numLives == 2)
            {
                life3.SetActive(false);
            }
            else if (numLives == 1)
            {
                life2.SetActive(false);
            }
            else if (numLives == 0)
            {
                life1.SetActive(false);
            }
        }else if (numLives == 0)
        {
            if (!GameObject.Find("Player").GetComponent<PlayerController>().gameOver)
            {
                Debug.Log("Game Over!");
                gameOverText.text = "GG!";
                GameObject.Find("Player").GetComponent<PlayerController>().gameOver = true;
            }
        }

    }

    public void increaseLife()
    {

        if (numLives < 3)
        {
            numLives++;
            if (numLives == 3)
            {
                life3.SetActive(false);
            }
            else if (numLives == 2)
            {
                life2.SetActive(false);
            }
            else if (numLives == 1)
            {
                life1.SetActive(false);
            }
        }

    }

}
