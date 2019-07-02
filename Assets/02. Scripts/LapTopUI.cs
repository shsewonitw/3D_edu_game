using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTopUI : MonoBehaviour {

    public Text passwordText;
    public Animator lapTopUIAnimator;
    public string correctAnswer;
    public GameObject eventObject;

    public void Login()
    {
        if (passwordText.text == correctAnswer)
        {
            Close();
            NoticeUI.instance.DisplayNotice("이제 강의 시작을 위해 교단 앞으로 이동해주십시오.");
            eventObject.SetActive(true);
            GameManager_Main.instance.UserCtrl(true);
            DialogueManager.instance.StartDialogue(EventLevelManager.instance.eventContents[EventLevelManager.instance.currentEventLevel].dialogue);
            EventLevelManager.instance.currentEventLevel++;
        }
    }

    public void Open()
    {
        lapTopUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

    public void Close()
    {
        lapTopUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
