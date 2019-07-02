using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PadlockController : MonoBehaviour {

    private Animator anim;
    private int unlockHash;
    public CylinderController[] Cylinders = new CylinderController[4];
    public int[] Combination = new int[4];

    public GameObject eventObject;
    public AnimationClip doorOpen;
    public Animation doorAnim;
    public PadLockUI padLockUI;
    public Button resultButton;

    // Use this for initialization
    void Start() {

        for (int i = 0; i < 4; i++)
        {
            GameObject go = transform.Find("BodyGroup").transform.Find(string.Format("Cylinder{0}", i + 1)).gameObject;
            Cylinders[i] = go.GetComponent<CylinderController>();
            Cylinders[i].padlockController = this;
        }
        anim = GetComponent<Animator>();
    }

    public bool CheckCombination() {
        bool correctCombination = true;
        for (int i = 0; i < 4; i++)
        {
            if (Cylinders[i].Moving || Combination[i] != Cylinders[i].CurrentPosition) {
                correctCombination = false;
                break;
            }
        }

        if (correctCombination) {
            anim.SetBool("IsOpen", true);
            SoundManager.instance.PlaySound("Effect_LockOpen");
        }
        return correctCombination;
    }

    public void ShowAfterEvent()
    {
        StartCoroutine(AfterEvent());
    }

    IEnumerator AfterEvent()
    {
        GameManager_Main.instance.ShowMainCamView();
        padLockUI.Close();
        doorAnim.clip = doorOpen;
        doorAnim.Play();
        SoundManager.instance.PlaySound("Effect_DoorOpen");

        yield return new WaitForSeconds(2.0f);

        eventObject.SetActive(true);
        NoticeUI.instance.DisplayNotice("이 교수가 강의실에 찾아왔습니다.");
        GameManager_Main.instance.UserCtrl(true);
        DialogueManager.instance.StartDialogue(EventLevelManager.instance.eventContents[EventLevelManager.instance.currentEventLevel].dialogue);
        resultButton.enabled = true;
    }
}
