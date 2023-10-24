using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    public static MovementController instance;
    [SerializeField] Transform cam;
    [SerializeField] float speed = 100f;

    Rigidbody rig;
    Vector2 newDir;

    void Awake()
    {
        if (!instance) instance = this;
        else Destroy(instance);
    }

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rig.AddForce((cam.forward.normalized * newDir.y + cam.right.normalized * newDir.x) * speed, ForceMode.Force);
    }

    void OnEnable()
    {
        MockHMDInputManager.moveAction += Move;
    }

    void Move(Vector2 dir)
    {
        newDir = dir;
    }

    void OnDisable()
    {
        MockHMDInputManager.moveAction -= Move;
    }
}