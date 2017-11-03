using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    int life = 5;
    bool entered = false;

    void OnCollisionEnter2D(Collision2D bounced)
    {
        print("Ball bounced");
        if (life == 5)
            gameObject.GetComponent<Renderer>().material.color = new Color(50, 0,0);
        if (life == 4)
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 50, 0);
        if (life == 3)
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        if (life == 2)
            gameObject.GetComponent<Renderer>().material.color = new Color(200, 0, 0);
        if (life == 1)
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 200, 0);
        if (life == 0)
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 200);
        //make ball go from black to white to indicate transition. How to set RGB values?
        if (life == 0)
        {
            Destroy(gameObject,.5f);
            print("Ball Destroyed");
            GameObject hud = GameObject.Find("HUDManager");
            hud.GetComponent<HUDManager>().incrementDevoured(); //How do I tell the hudmanager to increment the score when this is devoured?
        }
        life--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered)
        {
            entered = true;
            GameObject hud = GameObject.Find("HUDManager");
            hud.GetComponent<HUDManager>().incrementEntered();
        }
        
        //How to check from which direction the object passed? Check current position and if it's outside the circle, -life
    }
}
