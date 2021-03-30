using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public bool IsInputDisabled;
    public static event Action InteractEvent;
    public static event Action<Vector2> MoveEvent;
    public static event Action<Vector2> CameraMoveEvent;

    private static InputManager p_instance;
    public static InputManager Instance {
        get {

            if (p_instance == null) {
                p_instance = FindObjectOfType<InputManager>();
                if (p_instance == null) {
                    Debug.LogError("S-InputManager object not present in scene.");
                }
            }
            return p_instance;
        }

    }


    public void OnInteract() {
        //Debug.Log("On Interact with called");
        InteractEvent?.Invoke();
    }



    public void OnMove(Vector2 pos) {
        
        //string debg = MoveEvent == null ? "MoveEvent is null" : "MoveEvent is NOT null";
        //Debug.Log("IM: On Move with " + pos + "called, invoking. "+ debg );
        MoveEvent?.Invoke(pos);
    }


    public void OnCameraMove(Vector2 pos) {
        //Debug.Log("On Move with " + pos + "called");
        CameraMoveEvent?.Invoke(pos);
    }

    void Awake()
    {
        if (p_instance == null) {
            p_instance = this;
        }
        
    }

    private void Start() {
        
    }


    void Update()
    {
        
    }
}
