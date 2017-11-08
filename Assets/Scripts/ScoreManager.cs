using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text time;
    public Text score;
    
    public void setTime(int timePlayed)
    {
        time.text = "Time Played: " + timePlayed;
    }
    public void setScore(int scoreGot)
    {
        time.text = "Score: " + scoreGot;
    }
}
