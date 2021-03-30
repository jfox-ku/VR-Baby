using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Crib : MonoBehaviour
{
    public GameObject babeh;

    void Start()
    {
        EventController.CribEvent += CribActivate;
    }

    private void CribActivate() {
        babeh.transform.position += Vector3.up * 0.1f;
    }

    private void OnDestroy() {
        EventController.CribEvent -= CribActivate;
    }

}
