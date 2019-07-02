using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour {

    public Quiz[] quiz;

    public void TriggerQuiz()
    {
        QuizManager.instance.StartQuiz(quiz);
    }
}
