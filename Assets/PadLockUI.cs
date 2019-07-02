using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadLockUI : MonoBehaviour {

    public Animator padLockUIAnimator;

    public void Open()
    {
        padLockUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

    public void Close()
    {
        padLockUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
