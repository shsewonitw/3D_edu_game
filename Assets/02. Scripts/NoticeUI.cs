using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeUI : MonoBehaviour {

    #region Singleton

    public static NoticeUI instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BasicInventory found!");
            return;
        }
        instance = this;
    }

    #endregion  

    public Text noticeText;
    public int noticeTime;
    public Animator animator;

    public void DisplayNotice(string text)
    {
        StartCoroutine(ShowNotice(text));
        
    }


    IEnumerator ShowNotice(string text)
    {
        noticeText.text = text;

        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
        animator.SetBool("IsOpen", true);

        yield return new WaitForSeconds(noticeTime);

        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
        animator.SetBool("IsOpen", false);
    }


}
