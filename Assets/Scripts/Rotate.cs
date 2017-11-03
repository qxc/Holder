using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    int speed = 100;

	// Use this for initialization
	void Start () {
		
	}


    void OnTriggerEnter2D(Collider2D center)
    {
        //print("Ball Entered");
    }

    // Update is called once per frame

    void Update () {

        if (Input.GetKey("j"))
        {
            //print("s pushed");
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        }
        else if(Input.GetKey("k"))
        {
            //print("d pushed");
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
