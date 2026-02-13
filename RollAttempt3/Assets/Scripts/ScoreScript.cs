using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int playerScore;

    public ItemSpawner spawner;

    private TMP_Text ScoreText;

    public GameObject player; //{ball}
    public GameObject gameOverScreen; //{const TXT UI}
    public GameObject pauseScreen;

    private bool isPaused = false; //To keep track of the game state (paused or not)
    private bool isGameOver = false; //To keep track of the game state (game over or not)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = 0;
        spawner = GameObject.FindGameObjectWithTag("SpawnTagg").GetComponent<ItemSpawner>();
        ScoreText = GameObject.Find("scoreTxt").GetComponent<TMP_Text>();
        pauseScreen = GameObject.FindGameObjectWithTag("PauseTagg");
        pauseScreen.SetActive(false); //Initially, the pause screen is not visible
    }


    [ContextMenu("addScore")]
    public void addScore(int score)
    {
        if (!isPaused)
            playerScore += score;

        if (score == 1)
            spawner.NumCoins--;    //we recorded the score; update the number of coins on the board {See ItemSpawner.cs}
        else
            spawner.NumHearts--;
        ScoreText.text = "Score: " + playerScore.ToString(); //Update the playerScore on the UI element;

    }

    public void restartGame()     //Player wants to restart
    {
        SceneManager.LoadScene("Level1"); //we will allow to restart even if game is paused.
    }

    public void gameOver()
    {
        player.SetActive(false);  //Disable the ball {player}
        gameOverScreen.SetActive(true);     //show the GameOver TXT UI  
        isGameOver = true;
        //Next Version: Include Animations on the TXT UI Game

    }
    public void HomeScreen()
    {
        isPaused = false;
        SceneManager.LoadScene("Level0");

    }

    public void PauseResume()
    {

        if (!isGameOver)
        {

            if (isPaused)
            {
                Time.timeScale = 1f; // Resume the game
                isPaused = false;
                pauseScreen.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f; // Pause the game
                isPaused = true;
                pauseScreen.SetActive(true);
            }
        }
    }
}
