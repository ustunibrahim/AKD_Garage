using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GarageDoors : MonoBehaviour
{
    public Transform leftDoor; // Left door GameObject
    public Transform rightDoor; // Right door GameObject
    public float openAngle = 90f; 
    public float openSpeed = 2f; 
    private bool isOpen = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // When the 'E' key is pressed
        {
            isOpen = !isOpen;
        }


        // Open/close doors
        float targetAngle = isOpen ? openAngle : 0f;

        leftDoor.localRotation = Quaternion.Slerp(leftDoor.localRotation, Quaternion.Euler(0f, -targetAngle, 0f), Time.deltaTime * openSpeed);
        rightDoor.localRotation = Quaternion.Slerp(rightDoor.localRotation, Quaternion.Euler(0f, targetAngle, 0f), Time.deltaTime * openSpeed);
    }
}
