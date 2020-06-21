using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    // Game logic and data
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    private int score = 0;
    public int Score { get => score; set => score = value; }
    public int lives = 3;
    public List<GameObject> listSpawned = new List<GameObject>();
    private float secondsToChangeDiff = 10f;
    private float difficultyChange = 1.1f;
    float timePassed = 0;

    // Objects used in the canvas
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public Button restartButton;
    public Button gravityButton;

    // Flag for when the game has started (true) or game over (false)
    public bool isGameActive;

    // Flag for when the gravityButton is activated
    public bool gravityChanged = false;

    // Music and dreams and sound
    public AudioClip jumpSound;
    private AudioSource audioSource;


    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        /*Texto que se mostrara apenas empiece el juego*/
        UpdateScore(0);
        scoreText.gameObject.SetActive(true);
        livesText.text = "Lives : " + lives;
        livesText.gameObject.SetActive(true);
        gravityButton.gameObject.SetActive(true);
        gravityButton.interactable = false;

        titleScreen.SetActive(false);   
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        /*Desactivar lo que no se mostrará en la pantalla inicial del juego*/
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        livesText.gameObject.SetActive(false);
        gravityButton.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
    
        if (isGameActive && spawnRate>=0.1f)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= secondsToChangeDiff)
            {
                Debug.Log(secondsToChangeDiff + " seconds passed - difficulty increased");
                spawnRate /= difficultyChange;
                timePassed = 0f;
            }

        }

    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive) 
        {

            yield return new WaitForSeconds(spawnRate);
            if (!gravityChanged)
            {
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
            
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        //scoreText.text = "Score : " + Score;
        scoreText.GetComponent<ScoreChange>().UpdateScoreText(Score,Score+scoreToAdd);
        Score += scoreToAdd;
    }


    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }

    public void LifeUp()
    {
        lives++;
        livesText.text = "Lives : " + lives;
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives : " + lives;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Prototype 5");
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound,1.5f);
    }

}
