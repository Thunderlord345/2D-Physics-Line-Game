using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public int highScore;
    public int levelNumber;
    public GameObject[] stars;
    public GameObject banner;
    
    // Start is called before the first frame update
    void Start()
    {

       
        //tutorialHS = PlayerPrefs.GetInt("Highscore" + 0);
        // lvl1HS = PlayerPrefs.GetInt("Highscore" + 1);
        highScore = PlayerPrefs.GetInt("Highscore" + levelNumber);

    }

    // Update is called once per frame
    void Update()
    {
       
        HighScoreStarUpdate();
    }

   

    public void HighScoreStarUpdate()
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
