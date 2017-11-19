using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Transform ball;
    public Transform garbageBall;
    public Transform shirtBall;
    //int xRange = 8;
    //int yRange = 4;
    bool direction;
    Rigidbody2D myBody;
    private AudioSource meow;
    int upperRandom = 10; // range of numbers generated to determine which ball to spawn
    int frequencyGarbage = 2; // at least 1
    int frequencyShirt = 5; // Must be higher than frequencyGarbage
    

    // Use this for initialization
    void Start () {
        InvokeRepeating("spawnBall",0.0f,1.0f);
        direction = true;
        myBody = gameObject.GetComponent<Rigidbody2D>();
        meow = gameObject.GetComponent<AudioSource>();
    }

    void spawnBall()
    {
        Transform newBall;
        int randomBall = Random.Range(1, upperRandom);
        if (randomBall <= frequencyGarbage)
        {
                newBall = Instantiate(garbageBall, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0), Quaternion.identity);
        }

        else if(randomBall > frequencyGarbage && randomBall <= frequencyShirt){
                newBall = Instantiate(shirtBall, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0), Quaternion.identity);
            }
        else
            newBall = Instantiate(ball, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 0), Quaternion.identity);
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(350, 200, 0));
        rb.AddTorque(-5f);
        meow.volume = Random.Range(.02f, .3f);
        meow.Play();

    }
	/*void spawnBall()
    {
        int x = Random.Range(-xRange, -xRange+9);
        int y = Random.Range(-yRange, yRange+1);
        var newBall = Instantiate(ball, new Vector3(x, y, 0), Quaternion.identity);
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(0, 15, 0);
        rb.AddForce(new Vector3(350, 200-25*y, 0));
        //add some rng to how much force is applied

    }*/
    void Update()
    {
        float boundry = 2.5f;
        float accel = 3f;
        if (direction)
        {
            if (gameObject.transform.position.y > boundry)
                direction = false;
            else
                myBody.velocity = new Vector3(0, accel, 0);
        }
        else
            if (gameObject.transform.position.y < -boundry)
                direction = true;
            else
                myBody.velocity = new Vector3(0, -accel, 0);
    }
}
