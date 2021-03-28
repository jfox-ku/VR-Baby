using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    InputManager InputRef;

    
    public Rigidbody rb;
    public float moveMultiplier = 10f;
    public float speedLimit = 100f;

    void Start()
    {
        

        InputRef = InputManager.Instance;
        Debug.Log(InputRef ? "Starting listen on FP Controller" : "Input Manager NOT PRESENT");
        if (InputRef == null) return;
        InputRef.MoveEvent += Move;

    }

    private void Move(Vector2 dir) {
        //Debug.Log("Move FORCE dir: "+dir);
        Vector3 moveForce = new Vector3(dir.y * moveMultiplier, 0 , dir.x * moveMultiplier);
        //SpeedCheck
        if (SpeedCheck()) {
            rb.AddRelativeForce(moveForce);
        }
        
    }

  

    private bool SpeedCheck() {
        return true;
    }

    private void OnDestroy() {
        InputRef.MoveEvent -= Move;
    }


}
