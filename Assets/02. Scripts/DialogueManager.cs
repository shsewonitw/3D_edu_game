using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    #region Singleton

    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BasicInventory found!");
            return;
        }
        instance = this;
        dialogues = new Queue<Dialogue>();
    }

    #endregion

    public PlayerController playerController;

    public Text nameText;
    public Text dialogueText;
    public float typeSpeed = 0.1f;
    public Animator animDialogue;
    public bool typing;
    public bool IsPlaying = false;
    private Queue<Dialogue> dialogues;


    public void StartDialogue(Dialogue[] dialogue)
    {
        IsPlaying = true;

        if (playerController) playerController.enabled = false;
        if (animDialogue) animDialogue.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");

        dialogues.Clear();

        foreach (Dialogue tempDialogue in dialogue)
        {
            dialogues.Enqueue(tempDialogue);
        }

        DisplayNextSentence();
    }

    public void  DisplayNextSentence()
    {
        SoundManager.instance.PlaySound("Effect_ButtonClick");
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue tempDialogue = dialogues.Dequeue();

        nameText.text = tempDialogue.name;

        if(typing)
        {
            StopAllCoroutines();
            StartCoroutine(TypeSentence(tempDialogue.sentences));
        }
        else
        {
            dialogueText.text = tempDialogue.sentences;
        }

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void EndDialogue()
    {
        IsPlaying = false;
        if (animDialogue) animDialogue.SetBool("IsOpen", false);
        if (playerController) playerController.enabled = true;
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
