using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TriggerAction : MonoBehaviour
{
    public enum Hand { LEFT, RIGHT };
    [SerializeField] Hand hand;

    GrabAction grab;
    LineRenderer lineRen;
    Vector3 telePos;
    ISelectable uiSelected;
    TextMeshProUGUI mainMenuText;
    [SerializeField] float distance = 20f;

    public static Action<bool> showTeleportAreas;

    void Start()
    {
        grab = GetComponent<GrabAction>();
        lineRen = GetComponent<LineRenderer>();
        lineRen.enabled = false;
    }

    void Update()
    {
        if (lineRen.enabled)
        {
            lineRen.SetPosition(0, transform.position);
            lineRen.SetPosition(1, transform.position + transform.forward * distance);
        }
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward * distance, lineRen.startColor);
        if (lineRen.enabled)
        {
            lineRen.SetPosition(0, transform.position);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
            {
                if (hit.collider.CompareTag("TeleportArea"))
                {
                    telePos = hit.point;
                    uiSelected = null;
                    if (lineRen.startColor != Color.green)
                    {
                        lineRen.startColor = Color.green;
                        lineRen.endColor = Color.green;
                    }
                } 
                else if (hit.collider.CompareTag("HomeScreenOption"))
                {
                    uiSelected = hit.collider.gameObject.GetComponent<ISelectable>();
                    mainMenuText = hit.collider.gameObject.GetComponent<TextMeshProUGUI>();
                    mainMenuText.color = Color.green;
                    telePos = Vector3.zero;
                    if (lineRen.startColor != Color.green)
                    {
                        lineRen.startColor = Color.green;
                        lineRen.endColor = Color.green;
                    }
                }
                else if (hit.collider.gameObject.GetComponent<ISelectable>() != null)
                {
                    uiSelected = hit.collider.gameObject.GetComponent<ISelectable>();
                    telePos = Vector3.zero;
                    if (lineRen.startColor != Color.green)
                    {
                        lineRen.startColor = Color.green;
                        lineRen.endColor = Color.green;
                    }
                }
                else
                {
                    if (lineRen.startColor != Color.red)
                    {
                        telePos = Vector3.zero;
                        uiSelected = null;
                        lineRen.startColor = Color.red;
                        lineRen.endColor = Color.red;
                        if (mainMenuText != null)
                        {
                            mainMenuText.color = Color.white;
                            mainMenuText = null;
                        }
                    }
                }
            }
            else if (lineRen.startColor != Color.white)
            {
                telePos = Vector3.zero;
                uiSelected = null;
                lineRen.startColor = Color.white;
                lineRen.endColor = Color.white;
                if (mainMenuText != null)
                {
                    mainMenuText.color = Color.white;
                    mainMenuText = null;
                }
            }

            /*if (telePos != Vector3.zero)
            {
                lineRen.SetPosition(1, telePos);
            }
            else
            {
                lineRen.SetPosition(1, transform.forward * distance);
            }*/
        }
    }

    void OnEnable()
    {
        if (hand.Equals(Hand.LEFT))
        {
            VRInteractionController.leftTrigger += StartTeleport;
            //MockHMDInputManager.interactAction += StartTeleport;
        }
        else
        {
            VRInteractionController.rightTrigger += StartTeleport;
            //MockHMDInputManager.interactAction += StartTeleport;
        }
    }

    void StartTeleport(float value)
    {
        if (grab.objectsInGrabRange.Count == 0)
        {
            if (value == 1)
            {
                lineRen.enabled = true;
                showTeleportAreas?.Invoke(true);
            }
            else
            {
                PerformAction();
            }
        }
    }

    void PerformAction()
    {
        if (telePos != Vector3.zero)
        {
            VRInteractionController.instance.transform.position = telePos;
            //MockHMDInputManager.instance.transform.position = telePos;
        }
        else if (uiSelected != null)
        {
            uiSelected.Select();
        }
        lineRen.enabled = false;
        telePos = Vector3.zero;
        uiSelected = null;
        showTeleportAreas?.Invoke(false);
    }

    void OnDisable()
    {
        if (hand.Equals(Hand.LEFT))
        {
            VRInteractionController.leftTrigger -= StartTeleport;
            //MockHMDInputManager.interactAction -= StartTeleport;
        }
        else
        {
            VRInteractionController.rightTrigger -= StartTeleport;
            //MockHMDInputManager.interactAction -= StartTeleport;
        }
    }
}