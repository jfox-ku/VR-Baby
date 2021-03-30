using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Door : MonoBehaviour
{
    public Animator DoorAnimator;
    public int buttonNo;
    bool doorOpen;

    private void Start() {
        EventController.ButtonClickedEvent += CheckActivate;
    }

    private void CheckActivate(int inputNo) {
        Debug.Log("Check Activate called " + inputNo);
        if (buttonNo == inputNo) {
            Toggle();
        }

    }

    private void Toggle() {
        
        if (doorOpen) {
            DoorAnimator.Play("DoorClose", 0);
            doorOpen = false;
        } else {
            DoorAnimator.Play("DoorOpen", 0);
            doorOpen = true;
        }
        

        

    }
    private void OnDestroy() {
        EventController.ButtonClickedEvent -= CheckActivate;
    }

    private IEnumerator WaitForDoor() {

        yield return null;
    }

}
