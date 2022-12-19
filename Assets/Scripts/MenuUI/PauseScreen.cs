using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public bool isPaused;
    public GameObject background;

    Menus backToMain;

    private void Start()
    {
        backToMain = GetComponent<Menus>();
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
        SceneManager.LoadScene(backToMain.menu);
    }

    public void Restart()
    {
        
    }
}
