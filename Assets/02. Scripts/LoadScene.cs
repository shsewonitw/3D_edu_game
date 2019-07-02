using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    FadeInOut fadeInOut;

    void Start()
    {
        fadeInOut = FindObjectOfType<FadeInOut>();
    }

    public void LoadNextScene()
    {
        SoundManager.instance.PlaySound("Effect_GameStart");
        StartCoroutine(LoadSceneAfterFadeOut());
    }

    IEnumerator LoadSceneAfterFadeOut()
    {
        while(true)
        {
            yield return new WaitForSeconds(fadeInOut.animTime);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
