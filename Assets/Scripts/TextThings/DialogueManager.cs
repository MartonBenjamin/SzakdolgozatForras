using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //UI elemek 
    public Text speakerName;
    public Text message;
    //Animator
    public Animator animator;
    //Queue olyasmi mint a lista 
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        Cursor.lockState = CursorLockMode.None;
        speakerName.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); //Queba pakolja a mondatokat
        }
        ShowNextSentence();
    }

    public void ShowNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue(); //A soron következő üzenetet rakja a stentencebe
        StopAllCoroutines(); //Abban az esetben, hogyha az előző mondat megírása nem fejeződne be, de elindítanánk egy új mondat írását.
        StartCoroutine(SentenceTyper(sentence));
    }

    IEnumerator SentenceTyper(string sentence)
    {
        message.text = "";
        foreach (char letter in sentence.ToCharArray()) //Az inputot karakter tömbbé alakítja
        {
            message.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Cursor.lockState = CursorLockMode.Locked;

    }
    
}
