using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private int score;
    Text PlayerScoreText;
    
    public int Score
    {
        get { return this.score; }        
        set
        {
            this.score = value;
            UpdateScore();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerScoreText = GetComponent<Text>();
    }

    public void UpdateScore()
    {
        string scoreStr = string.Format("{0:00000}", score);
        PlayerScoreText.text = scoreStr;
    }

}
