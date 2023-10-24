using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class VRInteractionController : MonoBehaviour
{
    public static VRInteractionController instance;
    XRIDefaultInputActions actions;

    public static Action<float> leftTrigger;
    public static Action<float> rightTrigger;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            actions = new();
            actions.XRILeftHandInteraction.Enable();
            actions.XRIRightHandInteraction.Enable();
            actions.Enable();
        }
        else Destroy(gameObject);
    }

    void OnEnable()
    {
        actions.XRILeftHandInteraction.Activate.performed += InvokeLeftTrigger;
        actions.XRILeftHandInteraction.Activate.canceled += InvokeLeftTrigger;
        actions.XRIRightHandInteraction.Activate.performed += InvokeRightTrigger;
        actions.XRIRightHandInteraction.Activate.canceled += InvokeRightTrigger;
    }

    void InvokeLeftTrigger(InputAction.CallbackContext ctx)
    {
        leftTrigger?.Invoke(ctx.ReadValue<float>());
    }

    void InvokeRightTrigger(InputAction.CallbackContext ctx)
    {
        rightTrigger?.Invoke(ctx.ReadValue<float>());
    }

    void OnDisable()
    {
        actions.XRILeftHandInteraction.Activate.performed -= InvokeLeftTrigger;
        actions.XRILeftHandInteraction.Activate.canceled -= InvokeLeftTrigger;
        actions.XRIRightHandInteraction.Activate.performed -= InvokeRightTrigger;
        actions.XRIRightHandInteraction.Activate.canceled -= InvokeRightTrigger;
    }
}
