using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 1;

    public float clampXMin;
    public float clampXMax;

    public float clampYMin;
    public float clampYMax;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;

            turn.x = Mathf.Clamp(turn.x, clampXMin, clampXMax);
            turn.y = Mathf.Clamp(turn.y, clampYMin, clampYMax);

            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
