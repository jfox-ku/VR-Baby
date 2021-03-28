using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Curtain : MonoBehaviour
{
    public GameObject Curtain;
    public int buttonNo;

    private void Start() {
        EventController.Instance.ButtonClickedEvent += CheckActivate;
    }

    private void CheckActivate(int inputNo) {
        Debug.Log("Check Activate called "+inputNo);
        if(buttonNo == inputNo) {
            Toggle();
        }

    }

    public void Toggle() {
        if (Curtain.activeInHierarchy) {
            Curtain.SetActive(false);
        } else {
            Curtain.SetActive(true);
        }

    }

    private void OnDestroy() {
        EventController.Instance.ButtonClickedEvent -= CheckActivate;
    }

}
