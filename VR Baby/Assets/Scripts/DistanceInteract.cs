using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceInteract : Interactable
{
    public Transform ObjectToTrack;
    public float activationDistance = 10f;
    public bool inArea;

    public IntEvent DistanceEvent;
    public int ComfortEffect;

    private void Start() {
        var dist = GetDistance();
        inArea = dist < activationDistance;
        if (inArea) DistanceEvent.Raise(ComfortEffect);
    }

    public override void Activate() {
        var dist = GetDistance();
        if (inArea && activationDistance < dist) {
            inArea = false;
            DistanceEvent.Raise(-ComfortEffect);

        } else if (!inArea && activationDistance > dist) {
            inArea = true;
            DistanceEvent.Raise(ComfortEffect);
        }


    }



    public float GetDistance() {
        return Vector3.Distance(this.transform.position,ObjectToTrack.position);

    }

    private void OnDrawGizmosSelected() {

        Gizmos.color = new Color(.2f,.8f,.2f,.5f);
        Gizmos.DrawSphere(this.transform.position,activationDistance);
    }


}
