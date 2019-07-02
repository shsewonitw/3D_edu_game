using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChocolateboxUI : MonoBehaviour {

    public Text InputText;
    public TextMesh renderingText;
    public GameObject[] eventObject;
    public Animator chocolateBoxUIAnimator;
    public string correctAnswer;

    private void Update()
    {
        renderingText.text = InputText.text;
    }

    public void Check()
    {
        if(correctAnswer == InputText.text)
        {
            Close();
            NoticeUI.instance.DisplayNotice("Henry가 꽃다발을 건넵니다.");
            eventObject[0].SetActive(true);
            eventObject[1].SetActive(false);
            GameManager_Main.instance.UserCtrl(true);
            DialogueManager.instance.StartDialogue(EventLevelManager.instance.eventContents[EventLevelManager.instance.currentEventLevel].dialogue);
            EventLevelManager.instance.currentEventLevel++;
        }
    }

    public void Open()
    {
        chocolateBoxUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

    public void Close()
    {
        chocolateBoxUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
