using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public int score = 0;
    public int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "Score: " + score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score.ToString();

        //highscore saving
        if (highScore < score)
            PlayerPrefs.SetInt("Highscore", score);
    }
}
