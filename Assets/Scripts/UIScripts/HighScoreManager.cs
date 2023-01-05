using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    int highScore;
    public int levelNumber;

    public GameObject[] stars;
    ScoreManager sc;
    // Start is called before the first frame update
    void Start()
    {

        sc = FindObjectOfType<ScoreManager>();
        if (PlayerPrefs.HasKey("Highscore" + levelNumber))
        {
            highScore = PlayerPrefs.GetInt("Highscore" + levelNumber);
            StarDisplayHighScore();
        }
        else
        {
            highScore = PlayerPrefs.GetInt("Highscore" + levelNumber, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseScore()
    {
        if(highScore < sc.score)
        {
            PlayerPrefs.SetInt("Highscore" + levelNumber, sc.score);
        }
    }

    public void StarDisplayHighScore()
    {
        switch (highScore)
        {
            case 0:
                stars[0].SetActive(false);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                break;
            //If score is 10 (1 coin collected) show 1 star on levelselect
            case 10:
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                break;
            //If score is 20 (2 coins collected) show 2 stars on levelSelect 
            case 20:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);
                break;
            //If score is 30 (3 coins collected) show 3 stars on levelSelect 
            case 30:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);
                break;
        }
    }
}
