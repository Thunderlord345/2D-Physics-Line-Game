using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore;

    public GameObject[] stars;

    public int levelNumber;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore" + levelNumber);

    }


    // Update is called once per frame
    void Update()
    {
        UseScore();
        StarDisplayScore();

    }

    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;

    }

    public void UseScore()
    {
        if (score > highScore)
        {
           PlayerPrefs.SetInt("Highscore" + levelNumber, score);
        }

    }

    public void StarDisplayScore()
    {
        switch (score)
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
