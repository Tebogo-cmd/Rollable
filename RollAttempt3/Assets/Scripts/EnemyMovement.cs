using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject playerSphere;
   


    public ScoreScript LogicScript;


    public Transform ball;
    private NavMeshAgent Enemyagent;
    void Start()
    {
        Enemyagent = GetComponent<NavMeshAgent>();
        LogicScript = GameObject.FindGameObjectWithTag("ScoreTagg").GetComponent<ScoreScript>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            Enemyagent.SetDestination(ball.position); //enemy {cube aspect} moves towards ball {player}
            playerSphere.transform.position = Enemyagent.transform.position; // enemy is a composite shape {sphere + cube} -> make sphere move to  {{{probably not the best way to do this}}}
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        LogicScript.gameOver(); 
    }



}


