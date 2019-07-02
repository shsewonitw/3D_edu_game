using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneUI : MonoBehaviour {


    public BasicItem phone;
    public Animator phoneUIAnimator;
    public Animator phoneKeyPadAnimator;
    public Text phoneNumber;

    public GameObject eventObject;

    public string correctAnswer;
    public int inputCount = 0;

    void Start()
    {
        phoneNumber.text = correctAnswer.Substring(0, correctAnswer.Length - 4);
    }


    public void Call()
    {
        if (phoneNumber.text.Equals(correctAnswer))
        {
            Close();
            NoticeUI.instance.DisplayNotice("조교에게 연락하였습니다.");
            eventObject.SetActive(true);
            GameManager_Main.instance.UserCtrl(true);
            DialogueManager.instance.StartDialogue(EventLevelManager.instance.eventContents[EventLevelManager.instance.currentEventLevel].dialogue);
            EventLevelManager.instance.currentEventLevel++;
        }
        else
        {
            phoneKeyPadAnimator.SetTrigger("Vibration");
        }
    }

    public void InputDialNumber(string dialNumber)
    {
        if (inputCount < 4)
        {
            phoneNumber.text += dialNumber;
            inputCount++;
        }
    }

    public void Cancel()
    {
        if (inputCount > 0)
        {
            phoneNumber.text = phoneNumber.text.Substring(0, phoneNumber.text.Length - 1);
            inputCount--;
        }
    }

    public void Open()
    {
        phoneUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

    public void Close()
    {
        phoneUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

}
