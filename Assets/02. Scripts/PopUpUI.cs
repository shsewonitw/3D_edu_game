using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUpUI : MonoBehaviour {

    public Animator popUpUIAnimator;
    
    public void Open()
    {
        popUpUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
    
    public void Close()
    {
        popUpUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
