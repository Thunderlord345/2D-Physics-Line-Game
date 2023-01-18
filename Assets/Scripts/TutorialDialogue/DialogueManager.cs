using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] instructions;
    LineFactory lf;
    int instructIndex;

    public GameObject levelAudio;
    public AudioSource source;
    public AudioClip feedback;
    private void Start()
    {
        lf = FindObjectOfType<LineFactory>();

        lf.isRunning = false;
        levelAudio.SetActive(false);
        
    }

    private void Update()
    {
        TutorialPopUp();
    }

    void TutorialPopUp()
    {
        for (int i = 0; i < instructions.Length; i++)
        {
            if(i == instructIndex)
            {
                instructions[i].SetActive(true);
                
            }
            else
            {
                instructions[i].SetActive(false);
            }
        }
        // Move along the array with every tap
        if (Input.GetMouseButtonDown(0) && instructIndex < instructions.Length)
        {
            instructIndex++;
            source.PlayOneShot(feedback);
        }

        if(instructIndex == instructions.Length)
        {
            lf.isRunning = true;
            levelAudio.SetActive(true);
        }
    }
}
