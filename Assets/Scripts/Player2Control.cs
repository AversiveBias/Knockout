using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Control : MonoBehaviour
{
    public Text timeText;
    private void Update()   //called before rendering a frame
    {


    }
    public Text pointsText;
    public Text gameEnd;
    public bool gameOver=false;
    private int points;
    public float speed;
    private Rigidbody rb; //holds reference to object
    private int x, z;
    Vector3 randomPos;
    Vector3 returnVector = new Vector3(0, .5f, 0);
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        setPoints();
        gameEnd.text = "";
    }
    private void FixedUpdate() //Called just before calling any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal2") * speed;
        float moveVertical = Input.GetAxis("Vertical2") * speed;

        //Vector3 movement= new Vector3 (moveHorizontal,0.0f, moveVertical);
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text == "BLUE WINS!"))
        {
            rb.AddForce(moveHorizontal, 0.0f, moveVertical);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (rb.transform.position.y < -2 && gameOver==false)
        {
            rb.transform.position = returnVector;
            rb.velocity = new Vector3(0, 0, 0);
            gameEnd.text = "BLUE WINS!";
            gameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        x = Random.Range(-2, 2);
        z = Random.Range(-2, 2);
        randomPos = new Vector3(x, 0.5f, z);
        //Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.transform.position = randomPos;
            points++;
            setPoints();
        }
    }
    private void setPoints()
    {
        pointsText.text = "Player 2: " + points.ToString();
    }

}
