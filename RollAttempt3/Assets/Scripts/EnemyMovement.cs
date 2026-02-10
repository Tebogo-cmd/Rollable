using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject playerSphere;
    public GameObject gameOverScreen;
   


    public Transform player;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            playerSphere.transform.position = agent.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
       other.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);

       
    }
        
}


