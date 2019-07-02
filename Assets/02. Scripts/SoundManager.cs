using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    #region Singleton

    public static SoundManager instance;

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


    public void PlaySound(string clipName)
    {
        AudioSource audioSource = GameObject.Find(clipName).GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StopSound(string clipName)
    {
        AudioSource audioSource = GameObject.Find(clipName).GetComponent<AudioSource>();
        audioSource.Stop();
    }

}
