using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EventLevelManager : MonoBehaviour {


    #region Singleton

    public static EventLevelManager instance;

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

    public int currentEventLevel = 0;
    public EventContent[] eventContents;


	// Use this for initialization
	void Start () {
        NoticeUI.instance.DisplayNotice("학생들로부터 신뢰를 얻고, 무사히 강의를 마치십시오.");
	}

    public bool CompareEventLevel(int eventLevel)
    {
        if (currentEventLevel == eventLevel) return true;
        return false;
    }

    public void ShowEventByLevel(int eventLevel)
    {
        Debug.Log("Show event by eventLevel.");
        switch(eventLevel)
        {
            // case EventLevel: Item - Object - EventType

            case 0: // Eraser - BlackBoard - (None)

                NoticeUI.instance.DisplayNotice("칠판을 깨끗하게 지웠다.");

                GameObject blackBoard = eventContents[eventLevel].eventObject;
                Material[] materials = blackBoard.GetComponent<MeshRenderer>().materials;
                materials[1] = eventContents[eventLevel].newMaterial[0];
                materials[2] = eventContents[eventLevel].newMaterial[1];
                blackBoard.GetComponent<MeshRenderer>().materials = materials;

                DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                currentEventLevel++;

                break;

            case 1: // Book - Jenny - (Computing Quiz)

                DialogueManager.instance.EndDialogue();
                QuizManager.instance.StartQuiz(eventContents[eventLevel].quiz);

                StartCoroutine(AfterQuiz(eventLevel));
                currentEventLevel++;
                break;

            case 2: // Clue - SmartPhone - (Creativity Quiz)

                DialogueManager.instance.EndDialogue();
                GameObject phoneUI = eventContents[eventLevel].eventObject;
                phoneUI.GetComponent<PhoneUI>().Open();
                GameManager_Main.instance.UserCtrl(false);
                break;

            case 3: // Water - Certine Place - (None)

                NoticeUI.instance.DisplayNotice("김 조교가 출석을 부르기 시작합니다.");

                DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                currentEventLevel++;
                break;

            case 4: // Cola - Matthew - (Computing Quiz)

                DialogueManager.instance.EndDialogue();
                QuizManager.instance.StartQuiz(eventContents[eventLevel].quiz);

                StartCoroutine(AfterQuiz(eventLevel));
                currentEventLevel++;
                break;

            case 5: // CD - Lucas - (Creativity Quiz)

                DialogueManager.instance.EndDialogue();
                GameObject laptopUI = eventContents[eventLevel].eventObject;
                laptopUI.GetComponent<LapTopUI>().Open();
                GameManager_Main.instance.UserCtrl(false);
                break;

            case 6: // Papers - Zoe - (Computing Quiz)

                DialogueManager.instance.EndDialogue();
                QuizManager.instance.StartQuiz(eventContents[eventLevel].quiz);

                StartCoroutine(AfterQuiz(eventLevel));
                currentEventLevel++;
                break;

            case 7: // Chocolatebox - Henry - (Creativity Quiz)

                DialogueManager.instance.EndDialogue();
                GameObject chocolateBoxUI = eventContents[eventLevel].eventObject;
                chocolateBoxUI.GetComponent<ChocolateboxUI>().Open();
                GameManager_Main.instance.UserCtrl(false);
                break;

            case 8: // Roses_Bunch - Daniel - (None)

                NoticeUI.instance.DisplayNotice("Sophia가 기뻐합니다.");

                GameObject sophia = eventContents[eventLevel].eventObject;
                sophia.GetComponentInChildren<Animator>().SetBool("IsGlad", true);
                sophia.transform.rotation = Quaternion.Euler(new Vector3(0, 120, 0));

                DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                currentEventLevel++;
                break;

            case 9: // Culture Book - Alexa - (Computing Quiz)

                DialogueManager.instance.EndDialogue();
                QuizManager.instance.StartQuiz(eventContents[eventLevel].quiz);

                StartCoroutine(AfterQuiz(eventLevel));
                currentEventLevel++;
                break;

            case 10: // Glasses - Notice board - (None)

                NoticeUI.instance.DisplayNotice("안 보였던 게시글이 보입니다.");

                GameObject notice = eventContents[eventLevel].eventObject;
                notice.SetActive(true);

                DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                currentEventLevel++;
                break;

            case 11: // Notice - Door - (Creativity Quiz)

                DialogueManager.instance.EndDialogue();
                GameManager_Main.instance.ShowSubCamView();

                GameObject padLockUI = eventContents[eventLevel].eventObject;
                padLockUI.GetComponent<PadLockUI>().Open();
                GameManager_Main.instance.UserCtrl(false);
                GameManager_Main.instance.padlockInputController.SetActive(true);            
                break;
        }
    }

    IEnumerator AfterQuiz(int eventLevel)
    {
        while (true)
        {
            yield return null;
            if (!QuizManager.instance.IsPlaying)
            {
                switch (eventLevel)
                {
                    case 1:
                        DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                        NoticeUI.instance.DisplayNotice("Jenny가 김 조교에 전화번호에 대한 단서를 건넵니다.");
                        GameObject clue = eventContents[eventLevel].eventObject;
                        clue.SetActive(true);
                        break;
                    case 4:                 
                        DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                        NoticeUI.instance.DisplayNotice("Matthew가 비밀번호가 적힌 CD 케이스를 건넵니다.");
                        GameObject CD = eventContents[eventLevel].eventObject;
                        CD.SetActive(true);
                        break;
                    case 6:
                        DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                        NoticeUI.instance.DisplayNotice("Zoe가 두고 간 안경이 있다고 알려줍니다.");
                        GameObject glasses = eventContents[eventLevel].eventObject;
                        glasses.SetActive(true);
                        break;
                    case 9:
                        DialogueManager.instance.StartDialogue(eventContents[eventLevel].dialogue);
                        NoticeUI.instance.DisplayNotice("학생들이 모두 강의실을 떠났습니다.\n" +
                            "뒷정리를 마치고 강의실을 나가십시오.");
                        GameObject objectGroup = eventContents[eventLevel].eventObject;
                        objectGroup.SetActive(false);
                        break;
                }
                StopAllCoroutines();
            }
        }
    }
}
