using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Main : MonoBehaviour {

    #region Singleton

    public static GameManager_Main instance;

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

    public PlayerController playerController;
    public CameraController cameraController;
    public GameObject deactiveObject;
    public GameObject activeObject;
    public FadeInOut fadeInOut;
    public float phaseTime;
    public Transform playerTransform;
    public Transform commonTriggerTransform;
    public Camera maiaCam;
    public Camera subCam;
    public GameObject padlockInputController;

    private void Start()
    {
        SoundManager.instance.PlaySound("BGM_Main01");
    }

    public void UserCtrl(bool setBool)
    {
        if (playerController) playerController.enabled = setBool;
        if (cameraController) cameraController.enabled = setBool;        
    }

    public void DisplayNextPhase()
    {
        StartCoroutine(NextPhase());
    }

    IEnumerator NextPhase()
    {
        UserCtrl(false);
        fadeInOut.FadeOut();
        yield return new WaitForSeconds(fadeInOut.animTime);

        SoundManager.instance.StopSound("BGM_Main01");
        SoundManager.instance.PlaySound("BGM_Main02");
        deactiveObject.SetActive(false);
        activeObject.SetActive(true);

        cameraController.currentYaw = -180f;
        cameraController.currentZoom = 10f;
        yield return new WaitForSeconds(phaseTime);

        fadeInOut.FadeIn();
        yield return new WaitForSeconds(fadeInOut.animTime);

        UserCtrl(true);
  
        NoticeUI.instance.DisplayNotice("강의시간이 다 되었습니다.\n" +
            "강의를 마치고 마무리 하십시오.");
    }


    public void ShowSubCamView()
    {
        maiaCam.enabled = false;
        subCam.enabled = true;
    }

    public void ShowMainCamView()
    {
        maiaCam.enabled = true;
        subCam.enabled = false;
    }


}
