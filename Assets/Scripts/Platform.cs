using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    //add a platform and setup physics for it. Another dimension for players to use to control the trajectory of the balls.
    int speed = 5;
    void Update()
    {

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
