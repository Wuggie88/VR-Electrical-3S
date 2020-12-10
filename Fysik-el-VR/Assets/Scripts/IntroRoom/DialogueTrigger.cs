using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour{

    public Dialogue dialogue;
    public GameObject tHint;

    public void TriggerDialogue()
    {
        //best to used a singleton but lets keep it simple//
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void triggerHint()
    {
        tHint.SetActive(true);
    }
}
