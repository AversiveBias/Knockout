﻿using System.Collections;
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
    public int count=0;
    // Update is called once per frame
    void Update () {
        if (!(gameEnd.text == "RED WINS!" || gameEnd.text == "BLUE WINS!"))
        {
            timeLeft -= Time.deltaTime;


            timeText.text = "Time Left: " + timeLeft.ToString();


            if (timeLeft <= 0)
            {
                timeLeft = 10;
                transform.localScale *= .8f;
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
