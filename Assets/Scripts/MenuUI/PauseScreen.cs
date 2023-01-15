using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseScreen : MonoBehaviour
{
    public bool isPaused;
    public GameObject background;

    public string menu;
    public string levelSelect;

    public AudioSource audioSource;
    public AudioClip buttSound;

    private void Start()
    {
        background.SetActive(false);
        isPaused = false;
    }
    
    public void Pause()
    {
        audioSource.PlayOneShot(buttSound);
        Time.timeScale = 0f;
        background.SetActive(true);
        isPaused = true;
       
    }

    public void Resume()
    {
        audioSource.PlayOneShot(buttSound);
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
        audioSource.PlayOneShot(buttSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

  
}
