using UnityEngine;

public class CoinController : MonoBehaviour
{

    public ScoreScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("ScoreTagg").GetComponent<ScoreScript>(); //ScoreScript  carries the Game Logic, specifically the addScore(int score) method
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((new Vector3(0, 45, 15)) * Time.deltaTime * 2);

    }

    //called when then other collider enters a trigger.
    //In this case, when the ball  enters coin/heart trigger
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.layer == 3)   //The game object is a coin: Give +1 point
            logic.addScore(1);
        else
            logic.addScore(2);    //We have a heart: Give +2 points

       Destroy(gameObject);      //Not the most efficient way  { could have made the coin appear/disappear at random positions}!!
    }





}
