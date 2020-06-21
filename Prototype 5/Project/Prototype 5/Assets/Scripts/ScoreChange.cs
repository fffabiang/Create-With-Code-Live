using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.UIWidgets.gestures;
using Unity.UIWidgets.widgets;
using UnityEngine;

public class ScoreChange : MonoBehaviour
{

    bool scoreChange = false;
    int scoreToReach;
    int currentScore;
    GameManager gameManager;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        

        if (scoreChange && (currentScore < scoreToReach))
        {
            currentScore++;
            scoreText.text = "Score : " + currentScore;
        }
        else
        {
            scoreChange = false;
            scoreText.text = "Score : " + currentScore;
        }

    }

    public void UpdateScoreText(int oldScore, int newScore)
    {
        currentScore = oldScore;
        scoreToReach = newScore;
        scoreChange = true;
    }



}
