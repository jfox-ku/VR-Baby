using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public bool IsInputDisabled;
    public event Action InteractEvent;
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> CameraMoveEvent;

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
        //Debug.Log("On Interact with " + pos + "called");
        InteractEvent?.Invoke();
    }



    public void OnMove(Vector2 pos) {
        //Debug.Log("On Move with " + pos + "called");
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
        DontDestroyOnLoad(this);
    }


    void Update()
    {
        
    }
}
