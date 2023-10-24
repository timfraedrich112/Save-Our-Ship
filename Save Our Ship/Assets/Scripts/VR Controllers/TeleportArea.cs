using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArea : MonoBehaviour
{
    Renderer ren;
    Collider col;

    void Awake()
    {
        ren = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        ren.enabled = false;
        col.enabled = false;
    }

    void OnEnable()
    {
        TriggerAction.showTeleportAreas += ToggleTeleportAreas;
    }

    void ToggleTeleportAreas(bool input)
    {
        ren.enabled = input;
        col.enabled = input;
    }

    void OnDisable()
    {
        TriggerAction.showTeleportAreas -= ToggleTeleportAreas;
    }
}