using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioSource audioSource;

    public void SceneSelect(string scene)
    {
        StartCoroutine(ButtonAudio(scene));
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator ButtonAudio(string scene)
    {
        audioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        
    }
}
