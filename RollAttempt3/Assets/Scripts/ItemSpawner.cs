using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawner : MonoBehaviour
{

    public int NumCoins = 0;  //number of coins on the board
    public int NumHearts = 0;

    private const int MAX_COINS = 3;

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
        Vector3 randomPos = new Vector3(Random.Range(-7,7),0.6f, Random.Range(-6, 6)); //object to hold randomly generated  x and z positions on the board
        if (NumCoins < MAX_COINS)   
        {
            Instantiate(coin,randomPos,transform.rotation); // spwan another coin 
            ++NumCoins;
        }

        if ((NumHearts == 0) && (logic.playerScore % 3 == 0)) //Give a One heart only : we dont have heart and the player score is a multiple of 3
        {
            randomPos.x = Random.Range(-7, 7);
            randomPos.z = Random.Range(-6, 6);
            Instantiate(heart,randomPos,transform.rotation);
            ++NumHearts;
        }
        //Spawning Logic will probably change 
    }

}
