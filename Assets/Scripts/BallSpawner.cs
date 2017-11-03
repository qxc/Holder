using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Transform ball;
    int xRange = 8;
    int yRange = 4;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnBall",0.0f,1.0f);
	}
	void spawnBall()
    {
        int x = Random.Range(-xRange, -xRange+9);
        int y = Random.Range(-yRange, yRange+1);
        var newBall = Instantiate(ball, new Vector3(x, y, 0), Quaternion.identity);
        Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(0, 15, 0);
        rb.AddForce(new Vector3(350, 200-25*y, 0));
        //add some rng to how much force is applied

    }
}
