using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInteract : Interactable
{

    public bool Toggle;
    public int ComfortPower;
    public IntEvent ToggleEvent;

    void Start()
    {
        Toggle = false;

    }

    public override void Activate() {

        if (Toggle) {
            ToggleEvent.Raise(-ComfortPower);
            Toggle = false;

        } else {

            ToggleEvent.Raise(ComfortPower);
            Toggle = true;

        }


    }

}
