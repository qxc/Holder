using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager: MonoBehaviour {

    public Text devoured;
    public Text entered;
    public Text time;
    int timeLeft = 3;
    int numEntered = 0;
    int numDevoured = 0;

    public void updateScore(int enter, int dev)
    {
        entered.text = "Balls entered: " + enter;
        devoured.text = "Balls eaten: " + dev;
    }

    public void updateScore()
    {
        entered.text = "Balls entered: " + numEntered;
        devoured.text = "Balls eaten: " + numDevoured;
    }

    public void incrementEntered()
    {
        numEntered++;
        updateScore(numEntered, numDevoured);
    }
    public void incrementDevoured()
    {
        numDevoured++;
        updateScore(numEntered, numDevoured);
    }
    void Start()
    {
        updateTime();
        updateScore();
        InvokeRepeating("timer", 0.0f, 1.0f);
        GameObject hud = GameObject.Find("HUDManager");
        Object.DontDestroyOnLoad(hud); // this isn't working yet

    }
    public void timer()
    {
        if (timeLeft == 0)
        {
            SceneManager.LoadScene("GameOver");
            CancelInvoke();
        }
            //make sure UI is displaying stuff correctly
            //make sure all the stuff on the end of game screen is working
        updateTime();
        timeLeft--;
        print(timeLeft);
    }

    public void updateTime()
    {
        time.text = "Time Left: " + timeLeft;
    }
}
