using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCameraController : MonoBehaviour
{

    [SerializeField] private float lookSensitivity;
    [SerializeField] private float smoothing;


    private GameObject Player;
    private Vector2 smoothedVelocity;
    private Vector2 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = transform.parent.gameObject;
        InputManager.CameraMoveEvent += RotateCamera;
        InputManager.InteractEvent += SendRaycast;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void SendRaycast() {

        RaycastHit whatIHit;
        if (Physics.Raycast(transform.position, transform.forward, out whatIHit, Mathf.Infinity)) {

            

            if (whatIHit.distance < 10f) {
                Debug.Log(whatIHit.collider.name + " Distance: " + whatIHit.distance);
                var hit = whatIHit.transform.GetComponent<Interactable>();
                if (hit == null) {
                    hit = whatIHit.transform.GetComponentInParent<Interactable>();
                }

                hit?.Activate();

            }

        }

    }

    private void RotateCamera(Vector2 dir) {
        //Debug.Log("Rotate Camera called with dir: "+dir );
        dir = Vector2.Scale(dir, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x,dir.x,1f/smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, dir.y, 1f/smoothing);

        currentPos += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentPos.y,Vector3.right);
        Player.transform.localRotation = Quaternion.AngleAxis(currentPos.x, Player.transform.up);

    }

    private void OnDestroy() {
        if (InputManager.Instance == null) return;
        InputManager.CameraMoveEvent -= RotateCamera;
        InputManager.InteractEvent -= SendRaycast;
    }
}
