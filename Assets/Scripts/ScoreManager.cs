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

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    int levelNumber;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore" + levelNumber, 0);
        
    }


    // Update is called once per frame
    void Update()
    {
        StarDisplayScore();
    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score.ToString();

        //If score is greater than highscore, use score
        if (highScore < score)
            PlayerPrefs.SetInt("Highscore" + levelNumber, score);
    }

   
    public void StarDisplayScore()
    {
        switch (score)
        {
            case 0:
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            //If score is 10 (1 coin collected) show 1 star on levelselect
            case 10:
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
                break;
            //If score is 20 (2 coins collected) show 2 stars on levelSelect 
            case 20:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
                break;
            //If score is 30 (3 coins collected) show 3 stars on levelSelect 
            case 30:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
        }
    }
}
