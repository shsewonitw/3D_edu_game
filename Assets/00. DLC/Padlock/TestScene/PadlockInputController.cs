using UnityEngine;
using System.Collections;

public class PadlockInputController : MonoBehaviour {

    public PadlockController padlock;
    private CylinderController currentCylinder = null;
    private int currentCylinderIndex = 0;

    public Material normal;
    public Material selected;


    // Use this for initialization
    void Start () {
        if (!padlock) {
            Debug.LogError("Please assign a padlock to PadlockInputController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(currentCylinder.CurrentTarget + 1);
            }
        }


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(currentCylinder.CurrentTarget - 1);
            }
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentCylinder == null)
            {
                currentCylinder = padlock.Cylinders[currentCylinderIndex];
                currentCylinder.gameObject.GetComponent<Renderer>().material = selected;
            }

            if (currentCylinderIndex > 0)
            {

                currentCylinder.gameObject.GetComponent<Renderer>().material = normal;
                currentCylinderIndex -= 1;
                currentCylinder = padlock.Cylinders[currentCylinderIndex];
                currentCylinder.gameObject.GetComponent<Renderer>().material = selected;

            }


        }



        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (currentCylinder == null)
            {
                currentCylinder = padlock.Cylinders[currentCylinderIndex];
                currentCylinder.gameObject.GetComponent<Renderer>().material = selected;
            }

            if (currentCylinderIndex < padlock.Cylinders.Length - 1)
            {

                currentCylinder.gameObject.GetComponent<Renderer>().material = normal;
                currentCylinderIndex += 1;
                currentCylinder = padlock.Cylinders[currentCylinderIndex];
                currentCylinder.gameObject.GetComponent<Renderer>().material = selected;

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(3);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(4);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(5);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(6);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(7);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(8);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            if (currentCylinder)
            {
                currentCylinder.SetTargetPosition(9);
            }
        }
    }
}
