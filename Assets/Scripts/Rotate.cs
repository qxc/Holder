using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    int speed = 100;
    AudioSource source;

    public void setSpeed(int _speed)
    {
        speed = _speed;
    }

    void OnTriggerEnter2D(Collider2D center)
    {
        //print("Ball Entered");
    }

    // Update is called once per frame

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    void Update () {

        if (Input.GetKey("j"))
        {
            //print("s pushed");
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
            if (!source.isPlaying)
            {
                source.Play();
            }
            
        }
        else if(Input.GetKey("k"))
        {
            //print("d pushed");
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
            if (!source.isPlaying)
            {
                source.Play();
            }

        }
    }
}
