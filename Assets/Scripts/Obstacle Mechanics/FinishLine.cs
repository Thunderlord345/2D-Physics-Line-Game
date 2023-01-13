using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string levelToLoad;
    public string menu;
    public string levelSelect;
    public int levelToUnlock;
    public GameObject winScreen;
    public GameObject ball;
    public GameObject[] stars;
    ScoreManager sc;
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
        winScreen.SetActive(true);
        StarDisplayScore();
        Destroy(ball);

        yield return new WaitForSeconds(0.5f);
        
    }

    public void NextLevel()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(levelToLoad);
    }

    public void Menu()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(menu);
    }

    public void LevelSelect()
    {
        Debug.Log("pressed");
        SceneManager.LoadScene(levelSelect);
    }
    public void StarDisplayScore()
    {
        switch (sc.score)
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
