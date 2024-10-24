using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform holdPosition; 
    private GameObject currentObject; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Interact when "E" key is pressed
        {
            if (currentObject == null)
            {
               
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    if (hit.collider.CompareTag("Pickup")) 
                    {
                        currentObject = hit.collider.gameObject;
                        currentObject.transform.position = holdPosition.position;
                        currentObject.transform.parent = holdPosition;
                        currentObject.GetComponent<Rigidbody>().isKinematic = true; 
                    }
                }
            }
            else
            {
                // Drop
                currentObject.transform.parent = null;
                currentObject.GetComponent<Rigidbody>().isKinematic = false; 
                currentObject = null;
            }
        }
    }
}

