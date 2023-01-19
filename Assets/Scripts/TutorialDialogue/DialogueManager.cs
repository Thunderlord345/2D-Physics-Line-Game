using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] instructions;
    
    int instructIndex;
    public GameObject lineFact;
   
    public AudioSource source;
    public AudioClip feedback;

    PauseScreen ps;
    private void Start()
    {
        ps = FindObjectOfType<PauseScreen>();
        lineFact.SetActive(false);
        
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
        if (Input.GetMouseButtonDown(0) && instructIndex < instructions.Length && !ps.isPaused)
        {
            instructIndex++;
            source.PlayOneShot(feedback);
        }

        if(instructIndex == instructions.Length)
        {

            lineFact.SetActive(true);
        }
       
    }

   
}
