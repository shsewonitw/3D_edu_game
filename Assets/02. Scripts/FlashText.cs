using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashText : MonoBehaviour {

    public Text flashText;

    public float animTime = 2f;
    public float start = 0;
    public float end = 1f;
    public float time = 0f;

    void Start()
    {
        Flashing();
    }

    public void Flashing()
    {
        StartCoroutine(FadeOut());
    }
   
    

    IEnumerator FadeOut()
    {

        Color color = flashText.color;
        time = 0f;
        color.a = Mathf.Lerp(end, start, time);

        while (color.a > start)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(end, start, time);
            flashText.color = color;

            yield return null;
        }

        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {

        Color color = flashText.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < end)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            flashText.color = color;

            yield return null;
        }

        StartCoroutine(FadeOut());
    }
}
