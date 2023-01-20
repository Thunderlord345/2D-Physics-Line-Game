using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioSource audioSource;

    public GameObject clearPrefsPanel;

    

    public void SceneSelect(string scene)
    {
        StartCoroutine(ButtonAudio(scene));
    }

    public void Quit()
    {
        audioSource.PlayOneShot(buttonSound);
        Application.Quit();
    }

    IEnumerator ButtonAudio(string scene)
    {
        audioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        
    }

    public void Bin()
    {
        audioSource.PlayOneShot(buttonSound);
        clearPrefsPanel.SetActive(true);
    }
    public void ClearPrefs()
    {
        audioSource.PlayOneShot(buttonSound);
        PlayerPrefs.DeleteAll();
        clearPrefsPanel.SetActive(false);
    }

    public void Return()
    {
        audioSource.PlayOneShot(buttonSound);
        clearPrefsPanel.SetActive(false);
    }
}
