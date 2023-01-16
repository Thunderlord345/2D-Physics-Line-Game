using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string levelToLoad;
    public int levelToUnlock;
    public GameObject winScreen;
    public GameObject ball;
    public GameObject[] stars, blankStars;
    ScoreManager sc;

    public AudioSource source;
    public AudioClip winSound;
    private void Start()
    {
        sc = FindObjectOfType<ScoreManager>();
        winScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            StartCoroutine(Win());
        }
        
    }

    IEnumerator Win()
    {
        PlayerPrefs.SetInt("levelUnlocked", levelToUnlock);
        source.PlayOneShot(winSound);
        Destroy(ball);
        yield return new WaitForSeconds(0.4f);
        winScreen.SetActive(true);
        StarDisplayScore();
        

        
        
    }

    public void NextLevel()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(levelToLoad);
    }

   
    public void StarDisplayScore()
    {
        switch (sc.score)
        {
            case 0:
                stars[0].SetActive(false);
                stars[1].SetActive(false);
                stars[2].SetActive(false);

                blankStars[0].SetActive(true);
                blankStars[1].SetActive(true);
                blankStars[2].SetActive(true);
                break;
            //If score is 10 (1 coin collected) show 1 star on levelselect
            case 10:
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);

                blankStars[0].SetActive(false);
                blankStars[1].SetActive(true);
                blankStars[2].SetActive(true);
                break;
            //If score is 20 (2 coins collected) show 2 stars on levelSelect 
            case 20:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);

                blankStars[0].SetActive(false);
                blankStars[1].SetActive(false);
                blankStars[2].SetActive(true);
                break;
            //If score is 30 (3 coins collected) show 3 stars on levelSelect 
            case 30:
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                blankStars[0].SetActive(false);
                blankStars[1].SetActive(false);
                blankStars[2].SetActive(false);
                break;
        }
    }
}
