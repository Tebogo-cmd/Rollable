using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody body;
    public int speed = 3;
    public GameObject gameOverTxt;
    public bool isAlive;

    Vector2 nextPosition;
    void Start()
    {
        gameOverTxt.SetActive(false);
        isAlive = true;
        body = GetComponent<Rigidbody>();
        nextPosition = new Vector2(0,0);
        

    }

    private void OnEnable()
    {
        Debug.Log("OnEnable called");

    }
    private void OnDisable()
    {
        Debug.Log("Ball is Off");
    }

    private void Awake()
    {
        Debug.Log("AwakeCalled");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce((new Vector3(nextPosition.x, 0f, nextPosition.y)) * speed);
    }


    void OnMove(InputValue value)
    {
        if (isAlive)
        {
            nextPosition = value.Get<Vector2>();
          
        }
        else
            gameOverTxt.SetActive(true);

    
    }


}
