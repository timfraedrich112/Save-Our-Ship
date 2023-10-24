using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float camSpeed = 10f;
    Vector3 newDir = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnable()
    {
        MockHMDInputManager.lookAction += RotateCamera;
    }

    void RotateCamera(Vector2 dir)
    {
        newDir.x += -dir.y;
        newDir.y += dir.x;
        transform.rotation = Quaternion.Euler(newDir.x * camSpeed, newDir.y * camSpeed, 0f);
    }

    void OnDisable()
    {
        MockHMDInputManager.lookAction -= RotateCamera;
    }
}