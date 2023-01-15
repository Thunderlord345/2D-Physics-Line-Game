using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public bool isPaused;
    public GameObject background;

    public string menu;
    public string levelSelect;

    private void Start()
    {
        background.SetActive(false);
    }
    
    public void Pause()
    {
        Time.timeScale = 0f;
        background.SetActive(true);
        isPaused = true;
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        background.SetActive(false);
        isPaused = false;
    }

    public void BackToMenu()
    {
        Resume();
        SceneManager.LoadScene(menu);
        AudioSingleton.instance.Play("Menus");
    }

    public void LevelSelect()
    {
        Resume();
        SceneManager.LoadScene(levelSelect);
        AudioSingleton.instance.Play("Menus");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
