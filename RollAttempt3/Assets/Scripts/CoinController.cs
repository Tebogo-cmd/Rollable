using UnityEngine;

public class CoinController : MonoBehaviour
{

    public ScoreScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("ScoreTagg").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((new Vector3(0, 45, 15)) * Time.deltaTime * 2);

    }


    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.layer == 3)
            logic.addScore(1);
        else
            logic.addScore(2);

       Destroy(gameObject);
    }


    private void OnDestroy()
    {
        Debug.Log("Coin Gone");
    }


}
