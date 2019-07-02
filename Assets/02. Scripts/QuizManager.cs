using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour {

    #region Singleton

    public static QuizManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BasicInventory found!");
            return;
        }
        instance = this;
        quizes = new Queue<Quiz>();
    }

    #endregion


    public Image quizImage;
    public GameObject quizResult;
    public Button[] answerButton;
    public Animator animQuiz;

    public Queue<Quiz> quizes;
    public int quizCount = 0;
    public int point = 5;
    public bool IsPlaying = false;

    Quiz tempQuiz;
    bool quizTime = true;
    int correctAnswer = 0;
    int wrongAnswer = 0;
    bool showResult = false;

    public Slider ReliabilityGauge;

    float maxGuage = 100;
    float currentGuage = 0;

    public void StartQuiz(Quiz[] quiz)
    {
        IsPlaying = true;
        GameManager_Main.instance.UserCtrl(false);

        if (animQuiz) animQuiz.SetBool("IsOpen", true);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");

        InitQuiz();

        foreach (Quiz tempQuiz in quiz)
        {
            quizes.Enqueue(tempQuiz);
        }

        quizCount = quizes.Count;
        DisplayNextQuiz();
    }

    void InitQuiz()
    {
        quizes.Clear();
        quizImage.enabled = true;
        quizResult.SetActive(false);

        quizTime = true;
        correctAnswer = 0;
        wrongAnswer = 0;
        showResult = false;
    }

    public void DisplayNextQuiz()
    {
        if (!quizTime) return;
        

        if (quizes.Count == 0)
        {
            if (!showResult) DisplayResuilt();
            else 
            {
                EndQuiz();
                quizTime = false;
            }
            return;
        }

        tempQuiz = quizes.Dequeue();
        quizImage.sprite = tempQuiz.quizResource;
        quizTime = false;
        
    }

    public void EndQuiz()
    {
        StopAllCoroutines();
        StartCoroutine(GuageUp());

        if (animQuiz) animQuiz.SetBool("IsOpen", false);
        SoundManager.instance.PlaySound("Effect_InterfaceOnOff");
        GameManager_Main.instance.UserCtrl(true);

        IsPlaying = false;
    }

    public void CheckTheAnswer(int answerNumber)
    {
        if (quizTime) return;
        quizTime = true;
        if (quizCount == quizes.Count) return;
        if (tempQuiz.correctAnswer == answerNumber)
        {
            Debug.Log("You choose a correct answer...");
            SoundManager.instance.PlaySound("Effect_CorrectAnswer");
            correctAnswer++;
            quizImage.sprite = tempQuiz.quizSolution;
        }
        else
        {
            Debug.Log("You choose a wrong answer...");
            SoundManager.instance.PlaySound("Effect_WrongAnswer");
            wrongAnswer++;
            quizImage.sprite = tempQuiz.quizSolution;
        }
        quizCount--;
        
    }


    void DisplayResuilt()
    {
        showResult = true;
        quizImage.enabled = false;
        quizResult.SetActive(true);
        quizResult.GetComponentInChildren<Text>().text
            = "정답 : " + correctAnswer + "개\n"
            + "오답 : " + wrongAnswer   + "개\n"
            + "신뢰도 +" + correctAnswer * point + "상승";
        SoundManager.instance.PlaySound("Effect_QuizResult");
 
    }

    IEnumerator GuageUp()
    {
        int count = 0;
        while(count < correctAnswer)
        {
            count++;
            // Reilabiliy Guage
            currentGuage += point;
            ReliabilityGauge.value = currentGuage / maxGuage;
            SoundManager.instance.PlaySound("Effect_GaugePoint");
            yield return new WaitForSeconds(0.1f);
        }
    }
}