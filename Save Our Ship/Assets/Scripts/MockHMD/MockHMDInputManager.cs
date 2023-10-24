using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.AI;

public class MockHMDInputManager : MonoBehaviour
{
    public static MockHMDInputManager instance;
    public static Action<Vector2> moveAction;
    public static Action<Vector2> lookAction;
    public static Action<float> interactAction;
    MockHMDControls actions;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            actions = new();
            actions.Enable();
        }
        else
            Destroy(gameObject);
    }

    void OnEnable()
    {
        actions.MockHMD.Move.performed += InvokeMove;
        actions.MockHMD.Move.canceled += InvokeMove;
        actions.MockHMD.Look.performed += InvokeLook;
        actions.MockHMD.Look.canceled += InvokeLook;
        actions.MockHMD.Interact.performed += InvokeInteract;
        actions.MockHMD.Interact.canceled += InvokeInteract;
    }

    void InvokeMove(InputAction.CallbackContext ctx)
    {
        moveAction?.Invoke(ctx.ReadValue<Vector2>());
    }

    void InvokeLook(InputAction.CallbackContext ctx)
    {
        lookAction?.Invoke(ctx.ReadValue<Vector2>());
    }

    void InvokeInteract(InputAction.CallbackContext ctx)
    {
        interactAction?.Invoke(ctx.ReadValue<float>());
    }

    void OnDisable()
    {
        actions.MockHMD.Move.performed -= InvokeMove;
        actions.MockHMD.Move.canceled -= InvokeMove;
        actions.MockHMD.Look.performed -= InvokeLook;
        actions.MockHMD.Look.canceled -= InvokeLook;
        actions.MockHMD.Interact.performed -= InvokeInteract;
        actions.MockHMD.Interact.canceled -= InvokeInteract;
    }
}
