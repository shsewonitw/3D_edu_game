using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeAndGo : MonoBehaviour {

    public float speed;
    public float shiftTime;
    public bool reverse = true;

    private void Start()
    {
        StartCoroutine(ShiftDirection());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator ShiftDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(shiftTime);
            if (reverse)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, -180, 0));
                reverse = false;
            }
            else
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                reverse = true;
            }
        }
    }
}
