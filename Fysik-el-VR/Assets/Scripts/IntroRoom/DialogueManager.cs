using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public float typingSpeed;
    public GameObject diaBox;
        /*public Animator animator;*/


    // Queue = FIFO //
    private Queue<string> sentences;


    void Start()
    {
        sentences = new Queue<string>();
    }


    //the upstart of the dialogue//
    public void StartDialogue(Dialogue dialogue)
    {
        diaBox.SetActive(true);
        Debug.Log("dialogue Started");
            /*animator.SetBool("IsOpen", true);*/

        nameText.text = dialogue.name;
        sentences.Clear();

        //looping through the sentence//
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();
    }


    //the insurence of no repeat and playingnext sentence//
    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

        //if a coroutine is allready started: STOP IT//
        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
    }


    //looping throrgh the sentence words make it look like reallife typing//
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }


    //Kill it//
    void EndDialogue()
    {
            /*animator.SetBool("IsOpen", false);*/
        diaBox.SetActive(false);
        Debug.Log("Killed it!!!");
    }
}
