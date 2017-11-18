using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBall : Ball
{

    //Figure out how to override collision from ball that inherits from
    protected override void OnCollisionEnter2D(Collision2D bounced)
    {
        //print("Ball bounced");
        source.Play();
        source.pitch = source.pitch - .25f;
        plat.GetComponent<Platform>().changeSize(.2f);
        if (life == 5)
            renderer.material.color = new Color(255, 0, 0);
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
            Destroy(gameObject, 0.1f);
            //print("Ball Destroyed");
            hud.GetComponent<HUDManager>().decrementDevoured();
        }
        life--;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered)
        {
            entered = true;
            GameObject hud = GameObject.Find("HUDManager");
            hud.GetComponent<HUDManager>().decrementEntered();
        }
    }
}
