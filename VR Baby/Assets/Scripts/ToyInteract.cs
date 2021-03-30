using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyInteract : Interactable {

    public bool UseRelative = true;
    public float PushForce = 1f;
    public Vector3 RelativePushDir = Vector3.up;

    public override void Activate() {
        var rb = this.transform.GetComponent<Rigidbody>();


        if (rb != null) {
            if (!UseRelative) {
                rb.AddForce(RelativePushDir * PushForce, ForceMode.VelocityChange);
            } else {
                rb.AddRelativeForce(RelativePushDir * PushForce, ForceMode.VelocityChange);
            }

            
        } else {
            //this.transform.position += Vector3.up * 0.1f;
        }
        


    }
}