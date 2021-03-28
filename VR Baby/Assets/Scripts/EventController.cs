using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : MonoBehaviour
{
    private static EventController p_instance;

    public event Action<int> ButtonClickedEvent;
    public event Action CribEvent;

    public static EventController Instance {
        get {

            if (p_instance == null) {
                p_instance = FindObjectOfType<EventController>();
                if (p_instance == null) {
                    Debug.LogError("S-EventController object not present in scene.");
                }
            }
            return p_instance;
        }

    }
   

    // Update is called once per frame
    void Update()
    {
        

    }

    private void Start() {
        DontDestroyOnLoad(this);
    }

    public void OnButtonClick(int num) {
        ButtonClickedEvent?.Invoke(num);
    }

    public void CribClicked() {
        CribEvent?.Invoke();
    }

}
