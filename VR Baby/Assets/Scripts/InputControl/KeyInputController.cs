using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputController : InputManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputControl();
    }

    private void InputControl() {

        if (IsInputDisabled) return;

        MouseInputCheck();

        KeyInputCheck();


    }


    private void KeyInputCheck() {

        //1 if key down, 0 if not
        int keyW = Input.GetKey(KeyCode.W) ? 1 : 0;
        int keyA = Input.GetKey(KeyCode.A) ? 1 : 0;
        int keyS = Input.GetKey(KeyCode.S) ? 1 : 0;
        int keyD = Input.GetKey(KeyCode.D) ? 1 : 0;

        Vector2 moveDir = new Vector2(keyW-keyS,keyD-keyA);
        
        if(moveDir.magnitude != 0) {
            //Debug.Log("Key Input Controller move dir: "+moveDir);
            OnMove(moveDir);
        }

    }

    private void MouseInputCheck() {
        //Click check
        if (Input.GetMouseButtonDown(0)) {
            OnInteract();
        } else if (Input.GetMouseButtonDown(1)) {
            OnInteract();
        }

        //Mouse move check
        Vector2 inputValues = GetMouseMove();
        OnCameraMove(inputValues);

        //if(inputValues.magnitude != 0) {
        //    OnCameraMove(inputValues);
        //        }


    }


    private Vector2 GetMouseMove() {
        return new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }

    private Vector2 GetInputPosition() {
        //Debug.Log(Input.mousePosition);
        return Input.mousePosition;
    }


}
