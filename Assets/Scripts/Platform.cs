using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    int speed = 5;
    AudioSource source;
    float softSizeCap = 2.25f;
    float minSize = .4f;
    float slowRateDecrease = -.006f;
    float fastRateDecrease = -.06f;

    public void changeSize(float size)
    {
        transform.localScale += new Vector3(size, 0, 0);
    }

    public void setSpeed(int _speed)
    {
        speed = _speed;
    }

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        //changeSize(2f);
    }

    void Update()
    {
    //  print(transform.localScale.x);
        if(transform.localScale.x > minSize && transform.localScale.x < softSizeCap)
            transform.localScale += new Vector3(slowRateDecrease, 0, 0);
        else if(transform.localScale.x > softSizeCap)
            transform.localScale += new Vector3(fastRateDecrease, 0, 0);
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
}
