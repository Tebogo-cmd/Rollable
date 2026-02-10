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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScore = 0;
        spawner = GameObject.FindGameObjectWithTag("SpawnTagg").GetComponent<ItemSpawner>();
        ScoreText = GameObject.Find("scoreTxt").GetComponent<TMP_Text>();
    }


    [ContextMenu("addScore")]   
    public void addScore(int score)
    {
        playerScore+=score;
       
        if (score == 1)
            spawner.NumCoins--;    //we recorded the score; update the number of coins on the board {See ItemSpawner.cs}
        else
            spawner.NumHearts--;
        ScoreText.text = "Score: " + playerScore.ToString(); //Update the playerScore on the UI element;
            
    }

    public void restartGame()     //Player wants to restart
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    { 
        player.SetActive(false);  //Disable the ball {player}
        gameOverScreen.SetActive(true);     //show the GameOver TXT UI  
        //Next Version: Include Animations on the TXT UI Game

    }


}
