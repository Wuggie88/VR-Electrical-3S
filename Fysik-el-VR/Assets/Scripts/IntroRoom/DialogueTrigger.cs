using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour{

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //best to used a singleton but lets us keep it simple//
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
