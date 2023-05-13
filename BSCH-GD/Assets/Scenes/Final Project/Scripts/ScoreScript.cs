using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text scoreText;
    public Text endScoreText;
    public float currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float CurrentScore
    {
        get
        {
            return currentScore;
        }

        set
        {
            currentScore = value;
            UpdateHUD();
        }
    }

    public void UpdateHUD()
    {
        scoreText.text = "Points:" + (int)currentScore;
        endScoreText.text = "You Got " + (int)currentScore + " Points";
    }
}
