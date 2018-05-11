using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    Vector3 returnVector = new Vector3(0, .5f, 0);
    private int AIon = 1;
    public float speed;
    private Rigidbody rb; //holds reference to object
    private int x, z;
    
    private string AI = "aggressive";
    Vector3 randomPos;
    private float moveHorizontal;
    private float moveVertical;
    private double humanDistance;
    private double AIDistance;
    private GameObject humanPlayer;
    private Vector3 humanPos;
    private Vector3 direction;
    private Vector3 normalizedDirection;
    private float prevX;
    private float prevY;
    private float xVelocity;
    private float yVelocity;
    private Vector3 humanVelocity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //points = 0;
       // setPoints();
        gameEnd.text = "";
        prevX = -5;
        prevY = 0;
}
    private void FixedUpdate() //Called just before calling any physics calculations
    {

        humanPlayer = GameObject.Find("Player1");
       // print(humanPlayer.transform.position.x);
        //Vector3 movement= new Vector3 (moveHorizontal,0.0f, moveVertical);
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text == "BLUE WINS!"))
        {
            if (AIon == 0)
            {
                moveHorizontal = Input.GetAxis("Horizontal2") * speed;
                moveVertical = Input.GetAxis("Vertical2") * speed;
                rb.AddForce(moveHorizontal, 0.0f, moveVertical);
            }
            else
            {
                if (AI == "dumb but good")
                {
                    System.Console.WriteLine("Bold");
                    if (rb.position.x < 0)
                    {
                        moveHorizontal = 15;
                    }
                    else
                    {
                        moveHorizontal = -15;
                    }
                    if (rb.position.z < 0)
                    {
                        moveVertical = 15;
                    }
                    else
                    {
                        moveVertical = -15;
                    }
                    rb.AddForce(moveHorizontal, 0.0f, moveVertical);
                }
                else if (AI == "aggressive")
                {
                    //rb.AddForce(15, 0, 15);
                    if (humanPlayer!=null)
                    {
                        //rb.AddForce(15, 0.0f, 15);
                        humanPos = humanPlayer.transform.position;
                       
                        humanDistance = Math.Sqrt(humanPos.z * humanPos.z + humanPos.x * humanPos.x);
                        AIDistance = Math.Sqrt(rb.transform.position.z * rb.transform.position.z + rb.transform.position.x * rb.transform.position.x);
                        //print("Human: "+humanDistance);
                        //print("AI: "+AIDistance);
                        //pointsText.text = System.Convert.ToString(humanDistance)+"    "+System.Convert.ToString(AIDistance);
                        if (humanDistance < AIDistance + .5) //hes trying to get back to center
                        {
                            print("GOING TO CENTER");
                            //print("AI SPEED: " + rb.velocity);
                            if (rb.position.x < 0)
                            {
                                moveHorizontal = 15;
                            }
                            else
                            {
                                moveHorizontal = -15;
                            }
                            if (rb.position.z < 0)
                            {
                                moveVertical = 15;
                            }
                            else
                            {
                                moveVertical = -15;
                            }
                            rb.AddForce(moveHorizontal, 0.0f, moveVertical);
                        }
                        else //if he is closer to center, make him play aggro
                        {
                            print("HUNTING");
                            if (false)
                            {
                                xVelocity = humanPlayer.transform.position.x - prevX;
                                yVelocity = humanPlayer.transform.position.y - prevY;
                                humanVelocity = new Vector3(xVelocity, 0.0f, yVelocity);
                                direction = humanVelocity - rb.position;
                            }
                            else
                            {
                                direction = humanPos - rb.position;
                            }
                            normalizedDirection = Vector3.Normalize(direction)*7;
                            moveHorizontal = normalizedDirection.x;
                            moveVertical = normalizedDirection.z;
                            rb.AddForce(moveHorizontal, 0.0f, moveVertical);
                           
                        }
                    }
                }
                
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (rb.transform.position.y < -4 && gameOver==false)
        {
            rb.transform.position = returnVector;
            rb.velocity = new Vector3(0, 0, 0);
            gameEnd.text = "BLUE WINS!";
            gameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        x = UnityEngine.Random.Range(-2, 2);
        z = UnityEngine.Random.Range(-2, 2);
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
