using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour {

    public Image fadeImage;

    public float animTime = 2f;
    public float start = 0;
    public float end = 1f;
    public float time = 0f;

    public void FadeIn()
    {
        StartCoroutine(PlayFadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(PlayFadeOut());
    }

    IEnumerator PlayFadeOut()
    {
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;

            yield return null;
        }
    }

    IEnumerator PlayFadeIn()
    {

        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(end, start, time);

        while (color.a > 0f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(end, start, time);
            fadeImage.color = color;

            yield return null;
        }
    }
}
