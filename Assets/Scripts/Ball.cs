﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    protected int life = 5;
    protected bool entered = false;
    protected AudioSource source;
    protected new Renderer renderer;
    protected static GameObject hud;
    protected GameObject plat;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        renderer = gameObject.GetComponent<Renderer>();
        hud = GameObject.Find("HUDManager");
        plat = GameObject.Find("Platform");
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -5.5)
            Destroy(gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D bounced)
    {
        //print("Ball bounced");
        source.Play();
        source.pitch = source.pitch + .25f;
        plat.GetComponent<Platform>().changeSize(.2f);
        if (life == 5)
            renderer.material.color = new Color(255, 0,0);
        else if (life == 4)
            renderer.material.color = new Color(0, 50, 50);
        else if (life == 3)
            renderer.material.color = new Color(255, 190, 0);
        else if (life == 2)
            renderer.material.color = new Color(0, 255, 0);
        else if (life == 1)
            renderer.material.color = new Color(0, 0, 0);
        else if (life == 0)
        {
            gameObject.layer = 8;
            Destroy(gameObject,0.1f);
            //print("Ball Destroyed");
            hud.GetComponent<HUDManager>().incrementDevoured();
        }
        life--;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered)
        {
            entered = true;
            GameObject hud = GameObject.Find("HUDManager");
            hud.GetComponent<HUDManager>().incrementEntered();
        }
        
        //Destroy objects that go too far down - create floor that they trigger interact with. Maybe can check the type/name of the 2d collider?
        //How to check from which direction the object passed? Check current position and if it's outside the circle, -life
    }
}
