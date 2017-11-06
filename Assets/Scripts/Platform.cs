using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    //add a platform and setup physics for it. Another dimension for players to use to control the trajectory of the balls.
    int speed = 5;

    public void changeSize(float size)
    {
        transform.localScale += new Vector3(size, 0, 0);
    }

    public void setSpeed(int _speed)
    {
        speed = _speed;
    }

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
