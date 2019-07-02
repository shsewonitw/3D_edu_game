using UnityEngine;
using System.Collections;
using System;

public class CylinderController : MonoBehaviour {

   
   
    private float startRotation;
    private float endRotation;
    
    private float startRotationTime;
    public PadlockController padlockController;

    public int CurrentPosition;
    public int CurrentTarget;
    public bool Moving = false;
    private MoveDirection direction;
    private float initialRotation;
    private float angleBetweenPositions = 36f;

    public enum MoveDirection {
        Clockwise,
        Anticlockwise
    }

    // Use this for initialization
    void Start () {
        initialRotation = transform.localEulerAngles.z;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, initialRotation + (CurrentPosition * angleBetweenPositions));
    }

    
    public void SetTargetPosition(int target) {
        //set the target to 0-9
        while (target < 0) {
            target += 10;
        }
        CurrentTarget = target % 10;
        CheckPosition();
        
    }

    private void CheckPosition() {
        
        if (CurrentTarget != CurrentPosition)
        {
            //find out which direction is closer
            int clockwise = 0;
            int anti = 0;
            int pos = CurrentPosition;
            while (pos != CurrentTarget)
            {
                clockwise += 1;
                pos += 1;
                if (pos > 9)
                {
                    pos -= 10;
                }
            }
            pos = CurrentPosition;
            while (pos != CurrentTarget)
            {
                anti += 1;
                pos -= 1;
                if (pos < 0) {
                    pos += 10;
                }
            }

            if (clockwise < anti)
            {
                direction = MoveDirection.Clockwise;
            }
            else
            {
                direction = MoveDirection.Anticlockwise;
            }
        }
    }


    // Update is called once per frame
    void Update () {

        if (!Moving && CurrentTarget != CurrentPosition)
        {
            CheckPosition();
            startRotation = transform.localEulerAngles.z;
            if (direction == MoveDirection.Clockwise ) {
                endRotation = transform.localEulerAngles.z + 36;
            } else {
                endRotation = transform.localEulerAngles.z - 36;
            }
            startRotationTime = Time.time;
            Moving = true;
        }

        if (Moving)
        {
            float angle = Mathf.LerpAngle(startRotation, endRotation, Time.time - startRotationTime);
            transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
            if (Mathf.Abs(angle - endRotation) < 0.01f) {
                Moving = false;
                if (direction == MoveDirection.Clockwise)
                {
                    CurrentPosition = (CurrentPosition + 1) % 10;
                }
                else
                {
                    CurrentPosition -= 1;
                     if (CurrentPosition < 0) { 
                        CurrentPosition += 10;
                    }
                }
                
                if(CurrentPosition == CurrentTarget) { 
                    padlockController.CheckCombination();
                }

            }
        }

    }
}
