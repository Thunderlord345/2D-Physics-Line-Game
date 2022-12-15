using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public string play;
    public string instructions;
    public string credits;


    public void LevelSelect()
    {
        SceneManager.LoadScene(play);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(instructions);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
