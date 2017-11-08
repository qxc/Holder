using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager: MonoBehaviour {

    static bool init;
    public Text devoured;
    public Text entered;
    public Text time;
    public Text score;
    int timeLeft = 3;
    int numEntered = 0;
    int numDevoured = 0;
    //score is +1 if ball enters, +5 if devoured.

    public void updateScore(int enter, int dev)
    {
        entered.text = "Balls entered: " + enter;
        devoured.text = "Balls eaten: " + dev;
    }
    /*
    public void updateScore()
    {
        entered.text = "Balls entered: " + numEntered;
        devoured.text = "Balls eaten: " + numDevoured;
    }
    */
    public void updateScore()
    {
        score.text = "Score: " + (numEntered + numDevoured * 5);
    }
    public void incrementEntered()
    {
        numEntered++;
        updateScore();
    }
    public void incrementDevoured()
    {
        numDevoured++;
        updateScore();
    }
    void Start()
    {
        if (init == false)
        {
            updateTime();
            updateScore();
            InvokeRepeating("timer", 0.0f, 1.0f);
            //print("start");
            Object.DontDestroyOnLoad(gameObject);
            init = true;
        }
        else
            DestroyObject(gameObject);
        

    }
    public void timer()
    {
        if (timeLeft == 0)
        {
            CancelInvoke();
            SceneManager.LoadScene("GameOver");
        }
        //make sure UI is displaying stuff correctly
        //make sure all the stuff on the end of game screen is working
        else
        {
            //print("why");
            updateTime();
            timeLeft--;
        }
        //print(timeLeft);
    }

    public void updateTime()
    {
        time.text = "Time Left: " + timeLeft;
    }
}
