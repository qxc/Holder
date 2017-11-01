using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Transform ball;
    int xRange = 5;
    int yRange = 5;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBall",0.0f,1.0f);
	}
	void spawnBall()
    {
        int x = Random.Range(-xRange, xRange);
        int y = Random.Range(-yRange, yRange);
        var newBall = Instantiate(ball, new Vector3(x, y, 0), Quaternion.identity);
        newBall.Translate(-10, 0, 0);
        //Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(0, 10000, 0);

    }
}
