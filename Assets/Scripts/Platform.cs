using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
    public Text gameEnd;
    private float timeLeft = 5;
    public Text timeText;
    //private Rigidbody rb;
    public int count=0;
    private int xRotate, yRotate,zRotate;

    // Update is called once per frame
    void Update () {
        xRotate = Random.Range(-2, 2);
        yRotate = Random.Range(-2, 2);
        zRotate = Random.Range(-2, 2);
        transform.Rotate(xRotate*Time.deltaTime, 0, 0);
        transform.Rotate(0, yRotate*Time.deltaTime, 0);
        transform.Rotate(0, 0, zRotate*Time.deltaTime);
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text == "BLUE WINS!"))
        {
            timeLeft -= Time.deltaTime;


            timeText.text = "Time Left: " + timeLeft.ToString();


            if (timeLeft <= 0)
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
