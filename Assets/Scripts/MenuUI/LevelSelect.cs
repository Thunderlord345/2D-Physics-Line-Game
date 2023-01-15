using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;



public class LevelSelect : MonoBehaviour
{

    public Button[] levelButtons;
    public AudioClip audio;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        int levelUnlocked = PlayerPrefs.GetInt("levelUnlocked", 1); //Default level unlocked to be 0

        for (int i = 0; i < levelButtons.Length; i++)
        {

            if(i + 1 > levelUnlocked)
                levelButtons[i].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        StartCoroutine(ButtonSound(levelName));
        AudioSingleton.instance.Stop("Menus");
    }

    IEnumerator ButtonSound(string levelName)
    {
        audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(levelName);
        
    }

  
   
}
