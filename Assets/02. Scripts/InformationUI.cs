using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour {

    public Image informationImage;
    public Sprite[] informationSprites;
    public Text pageText;
    public Animator informationUIAnimator;

    public int page = 1;
    public int totalPage;
    public int index = 0;
    public bool IsOpen;


    private void Start()
    {
        totalPage = informationSprites.Length;
        informationImage.sprite = informationSprites[index];
        pageText.text = "Page " + page + " / " + totalPage;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1) )
        {
            Open();
        }
    }

    public void NextInfo()
    {
        if(page < totalPage)
        {
            page++;
            index++;
            informationImage.sprite = informationSprites[index];
            pageText.text = "Page " + page + " / " + totalPage;
            SoundManager.instance.PlaySound("Effect_ButtonClick");
        }
    }

    public void  PreviousInfo()
    {
        if(1 < page)
        {
            page--;
            index--;
            informationImage.sprite = informationSprites[index];
            pageText.text = "Page " + page + " / " + totalPage;
            SoundManager.instance.PlaySound("Effect_ButtonClick"); 
        }
    }

    public void Open()
    {
        IsOpen = true;
        informationUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }

    public void Close()
    {
        IsOpen = false;
        informationUIAnimator.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
