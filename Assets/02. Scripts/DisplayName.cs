using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour {

    public Text nameText;
    public Color textColor = new Color(0,0,0,1);
    public int fontSize = 14;
    public float displayDistance;


    private Transform playerTransform;


    void Start()
    {
        nameText.text = this.transform.parent.gameObject.name;
        nameText.color = textColor;
        nameText.fontSize = fontSize;

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float fDistance = Vector3.Distance(transform.position, playerTransform.position);

        if (fDistance < displayDistance)
            nameText.enabled = true;
        else
            nameText.enabled = false;
    }
}
