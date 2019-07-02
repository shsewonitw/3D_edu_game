using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Opening : MonoBehaviour {

    public GameObject commomTrigger;
    public InformationUI informationUI;
    public bool once;

	void Start () {
        SoundManager.instance.PlaySound("BGM_Opening");
        informationUI.Open();
    }

    private void Update()
    {
        if (DialogueManager.instance.IsPlaying) commomTrigger.SetActive(true);
        if (!informationUI.IsOpen && !once)
        {
            NoticeUI.instance.DisplayNotice("사무실에 누군가 찾아온 것 같습니다.");
            once = true;
        }
    }
}
