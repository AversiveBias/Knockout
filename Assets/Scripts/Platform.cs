using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
    public Text gameEnd;
    private int testing =0;
    private float timeLeft = 5;
    public Text timeText;
    //private Rigidbody rb;
    public int count=0;
    private int xRotate, yRotate,zRotate;
    private int rotationSpeed = 3;
    // Update is called once per frame
    void Update () {
        if (testing == 0)
        {
            xRotate = Random.Range(-1*rotationSpeed, rotationSpeed);
            yRotate = Random.Range(-1*rotationSpeed, rotationSpeed);
            zRotate = Random.Range(-1*rotationSpeed, rotationSpeed);
            transform.Rotate(xRotate * Time.deltaTime, 0, 0);
            transform.Rotate(0,yRotate * Time.deltaTime, 0);
            transform.Rotate(0, 0,zRotate * Time.deltaTime);
           
        }
     
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text == "BLUE WINS!"))
        {
            timeLeft -= Time.deltaTime;


            timeText.text = "Time Left: " + timeLeft.ToString();


            if (testing==0 && timeLeft <= 0)
            {
                timeLeft = 10;
                transform.localScale *= .9f;
                count++;
            }
        }
        else
        {
            timeText.text = "Game Over...";
        }

    }
    public int getCount()
    {
        return count;
    }
}
