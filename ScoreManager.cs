using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    //public float scoreCount;
    public static int scoreCount = 0;
    public static int hiScoreCount = 0;

    //löschen
    //public float pointsPerSecond;

    public bool scoreIncreasing;


    //// Use this for initialization
    void Start () {

    }

    //// Update is called once per frame
    void Update () {

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
        }

        scoreText.text = "Score: " + scoreCount;
        hiScoreText.text = "High Score: " + hiScoreCount;


    }
}
