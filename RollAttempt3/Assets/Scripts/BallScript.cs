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


    // Update is called once per frame
    void FixedUpdate()
    {
        body.AddForce((new Vector3(nextPosition.x, 0f, nextPosition.y)) * speed);

        if(Mouse.current.leftButton.isPressed)
        {
            body.AddForce((new Vector3(0, 0f, 2f)),ForceMode.Acceleration);
        }
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
