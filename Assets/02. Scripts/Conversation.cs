using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class Conversation : Interactable {

    public DialogueTrigger eventDialogue;
    public DialogueTrigger commonDialogue;
    public int eventLevel;

    public override void Interact()
    {
        base.Interact();

        StartDialogue();
    }



    void StartDialogue()
    {
        if (EventLevelManager.instance == null)
        {
            if (commonDialogue != null) commonDialogue.TriggerDialogue();
        }
        else
        {
            if (eventLevel == EventLevelManager.instance.currentEventLevel)
            {
                if (eventDialogue != null) eventDialogue.TriggerDialogue();
            }
            else
            {
                if (commonDialogue != null) commonDialogue.TriggerDialogue();
            }
        }
    }
}
