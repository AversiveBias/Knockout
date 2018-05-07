using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void Update()   //called before rendering a frame
    {



    }
    //public Text pointsText;
    public Text gameEnd;
    public bool gameOver = false;
    private int points;
    public float speed;
    int x, z;
    int count;
    Vector3 randomPos;
    Vector3 returnVector=new Vector3(0,.5f,0);
    private Rigidbody rb; //holds reference to object
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        points = 0;
        setPoints();
        
    }
    private void FixedUpdate() //Called just before calling any physics calculations
    {
        float moveHorizontal = Input.GetAxis("Horizontal1") * speed;
        float moveVertical = Input.GetAxis("Vertical1") * speed;


        //Vector3 movement= new Vector3 (moveHorizontal,0.0f, moveVertical);
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text=="BLUE WINS!"))
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
            gameEnd.text = "RED WINS!";
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        x = Random.Range(-5, 5);
        z = Random.Range(-5, 5);
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
        //pointsText.text = "Player 1: " + points.ToString();
    }
}