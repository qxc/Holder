using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager: MonoBehaviour {

    public Text time;
    public Text score;
    int timeLeft = 60;
    static int currentScore = 0;
    bool isPaused = false;
    public Text paused;
    AudioSource source;
    //score is +1 if ball enters, +5 if devoured.
    public void updateScore()
    {
        score.text = "Score: " + currentScore;
    }
    public void incrementEntered()
    {
        currentScore++;
        updateScore();
    }
    public void incrementDevoured()
    {
        currentScore = currentScore + 5;
        updateScore();
    }
    public void decrementEntered()
    {
        currentScore--;
        updateScore();
    }
    public void decrementDevoured()
    {
        print(currentScore);
        currentScore = currentScore - 5;
        updateScore();
        print(currentScore);
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            currentScore = 0;
            updateTime();
            updateScore();
            InvokeRepeating("timer", 0.0f, 1.0f);
            source = gameObject.GetComponent<AudioSource>();
        }
        else if(SceneManager.GetActiveScene().name == "GameOver")
        {
            updateScore();
            /* Can we use playerprefs to save score from session to session and also to populate the high score board?
            PlayerPrefs.SetInt("Score", 20);
            PlayerPrefs.GetInt("Score");
            print("gameOver");
            */
        }
        /*if (init == false)
        {
            
            //print("start");
            Object.DontDestroyOnLoad(gameObject);
            init = true;
        }
        else
            DestroyObject(gameObject);
        */

    }
    public void timer()
    {
        if (timeLeft == 5)
            source.Play();

        if (timeLeft == 0)
        {
            CancelInvoke();
            SceneManager.LoadScene("GameOver");
            //GameObject.Find("score").GetComponent<Text>().text = "test";
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

    private void Update()
    {
        if (Input.GetKeyDown("space")){
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
                paused.text = "Game Paused. (Space)";
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                paused.text = "";
            }
            
        }
    }

    public void updateTime()
    {
        time.text = "Time Left: " + timeLeft;
    }
}
