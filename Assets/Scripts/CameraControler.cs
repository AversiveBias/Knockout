using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - (Player1.transform.position + Player2.transform.position);
	}
	
	// Update is called once per frame
	void LateUpdate () {            //guaranteed to run after all items have been processed
        transform.position = (Player1.transform.position + Player2.transform.position)/2 +offset;
	}
}
