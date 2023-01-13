using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public int highScore;

    
    public GameObject[] stars;
    public GameObject banner;
    ScoreManager sc;
    // Start is called before the first frame update
    void Start()
    {

        sc = FindObjectOfType<ScoreManager>();
        if (PlayerPrefs.HasKey("Highscore" + sc.levelNumber))
        {
            highScore = PlayerPrefs.GetInt("Highscore" + sc.levelNumber);
            
        }
        else
        {
            highScore = PlayerPrefs.GetInt("Highscore" + sc.levelNumber, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        UseScore();    
        StarDisplayHighScore();
    }

    public void UseScore()
    {
        if(highScore < sc.score)
        {
            PlayerPrefs.SetInt("Highscore" + sc.levelNumber, sc.score);
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
                banner.SetActive(false);
                break;
            //If score is 10 (1 coin collected) show 1 star on levelselect
            case 10:
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
                banner.SetActive(true);
                break;
            //If score is 20 (2 coins collected) show 2 stars on levelSelect 
            case 20:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);
                banner.SetActive(true);
                break;
            //If score is 30 (3 coins collected) show 3 stars on levelSelect 
            case 30:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);
                banner.SetActive(true);
                break;
        }
    }
}
