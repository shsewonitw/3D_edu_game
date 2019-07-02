using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFacingBillboard : MonoBehaviour {

    public Camera mainCam;

    void Update()
    {
        transform.LookAt(transform.position + mainCam.transform.rotation * Vector3.forward, mainCam.transform.rotation * Vector3.up);
    }
}
