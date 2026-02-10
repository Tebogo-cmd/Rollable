using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawner : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int NumCoins = 0;
    public int NumHearts = 0;


    public ScoreScript logic;

    public GameObject coin;
    public GameObject heart;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("ScoreTagg").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomPos = new Vector3(Random.Range(-7,7),0.6f, Random.Range(-6, 6));
        if (NumCoins < 1)
        {
            Instantiate(coin,randomPos,transform.rotation);
            ++NumCoins;
        }

        if ((NumHearts == 0) && (logic.playerScore % 2 == 0))
        {
            randomPos.x = Random.Range(-7, 7);
            randomPos.z = Random.Range(-6, 6);
            Instantiate(heart,randomPos,transform.rotation);
            ++NumHearts;
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
