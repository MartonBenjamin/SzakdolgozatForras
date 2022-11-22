using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogue : MonoBehaviour
{
    
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
            TriggerDialogue();

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}

