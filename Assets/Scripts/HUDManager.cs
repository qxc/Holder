using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager: MonoBehaviour {

    public Text devoured;
    public Text entered;
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
}
