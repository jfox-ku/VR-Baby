using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{

    public int myID;

    public override void Activate() {
        Debug.Log("Button " + myID + "pressed!");
        EventController.Instance.OnButtonClick(myID);
    }

    
}
