using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CribInteract : Interactable
{
    public override void Activate() {
        base.Activate();

        EventController.Instance.CribClicked();
    }
}
