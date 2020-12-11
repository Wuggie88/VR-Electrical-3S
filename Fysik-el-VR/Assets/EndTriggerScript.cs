using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerScript : MonoBehaviour
{
  
    bool endTextShown = false;
    public Dialogue dialogue;
    public GameObject dialogueManager;



    public void OnTriggerEnter(Collider collider)
    {
        //Starting the dialog//
        if(collider.tag == "Player")
        {
            Debug.Log("EndTrigger entered");
            if (endTextShown == false)
            {
                Debug.Log("endDialogueStarted");
                dialogueManager.GetComponent<EndDialogueManager>().StartDialogue(dialogue);
                endTextShown = true;
            }
        }
    }
}
