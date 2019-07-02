using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    public Image quizImage;
    public Text quizScore;
    public Button[] answerButton;
    public Animator quizUIAnimator;
    public Quiz[] quizes;
    public int quizIndex = 0;
    public GameObject clue;

    public bool quizTime = true;
    public int point = 5;
    int correctAnswer = 0;
    int wrongAnswer = 0;
    
    

    void Start()
    {
        DisplayQuiz();
    }

    public void DisplayQuiz()
    {
        if (!quizTime) return;

        if (quizIndex < quizes.Length)
        {
            quizImage.sprite = quizes[quizIndex].quizResource;
            quizImage.SetNativeSize();   
        }

        quizTime = false;

        if (quizIndex == quizes.Length) DisplayScore();
    }
    
    public void DisplaySolution()
    {
        quizImage.sprite = quizes[quizIndex].quizSolution;
        quizImage.SetNativeSize();
    }


    public void CheckTheAnswer(int answerNumber)
    {
        if (quizTime) return;
        if (quizIndex == quizes.Length) return; 
        if(quizes[quizIndex].correctAnswer == answerNumber)
        {
            Debug.Log("You choose a correct answer...");
            correctAnswer++;
            DisplaySolution();
        }
        else
        {
            Debug.Log("You choose a wrong answer...");
            wrongAnswer++;
            DisplaySolution();
        }
        quizTime = true;
        quizIndex++;
    }


    void DisplayScore()
    {
        quizImage.sprite = null;
        quizScore.enabled = true;
        quizScore.text = "정답 : " + correctAnswer + "개\n"
            + "오답 : " + wrongAnswer + "개\n"
            + "신뢰도 " + correctAnswer * point + "상승";
    }

    public void Close()
    {
        if (quizIndex == quizes.Length)
        {
            quizUIAnimator.SetBool("IsOpen", false);
            NoticeUI.instance.DisplayNotice("Jenny가 조교번호와 관련된 단서를 건넵니다.");
            clue.SetActive(true);
            EventLevelManager.instance.currentEventLevel++;
        } 
    }
}
