using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int playerScore;

    public ItemSpawner spawner;

    private TMP_Text ScoreText;

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
        ScoreText.text = "Score: " + playerScore;
        if (score == 1)
            spawner.NumCoins--;
        else
            spawner.NumHearts--;

            Debug.Log("CurrentScore: " + playerScore);
    }

  


}
