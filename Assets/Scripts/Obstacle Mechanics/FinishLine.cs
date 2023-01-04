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

    private void Start()
    {
        winScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Win());
    }

    IEnumerator Win()
    {
        PlayerPrefs.SetInt("levelUnlocked", levelToUnlock);
        winScreen.SetActive(true);
        Destroy(ball);

        yield return new WaitForSeconds(0.5f);
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
