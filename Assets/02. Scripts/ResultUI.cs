using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour {

    public Slider reliabilityGuage;
    public Animator resultUIAnimator;
    public Image gameClear;
    public Image gameOver;
    public Text informationText;
    public Text comentText;
    public float typeSpeed;
    public Button resultButton;


    public float clearPoint;

    public void ShowResult()
    {
        DialogueManager.instance.EndDialogue();
        resultUIAnimator.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
        

        int realiabilityPoint = (int)(reliabilityGuage.value * 100f);

        if (clearPoint <= realiabilityPoint)
        {
            gameClear.enabled = true;
            string sentence = "축하드립니다. 학생들의 반응이 좋네요!";
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            SoundManager.instance.PlaySound("Effect_GameResultPositive");
        }
        else
        {
            gameOver.enabled = true;
            string sentence = "아쉽지만, 좀 더 노력하셔야겠네요...";
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
            SoundManager.instance.PlaySound("Effect_GameResultNegative");
        }
        informationText.text = "총 획득한 신뢰도 : +" + realiabilityPoint + " point" +
            "(커트라인 : +" + clearPoint + " point)";


    }

    IEnumerator TypeSentence(string sentence)
    {
        comentText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            comentText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void Close()
    {
        resultUIAnimator.SetBool("IsOpen", false);
        resultButton.enabled = false;
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
    }
}
