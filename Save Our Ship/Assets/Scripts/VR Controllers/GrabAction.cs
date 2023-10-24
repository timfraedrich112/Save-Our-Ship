using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using System.Linq;

public class GrabAction : MonoBehaviour
{
    public enum Hand { Left, Right };
    [SerializeField] Hand thisHand;

    FixedJoint joint;
    public List<Rigidbody> objectsInGrabRange;
    public Rigidbody heldObject;

    [SerializeField] float throwStrength = 1f;
    Vector3 controllerAngularVelocity, controllerPreviousRotation, controllerVelocity, controllerPreviousPosition;

    void Awake()
    {
        joint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        controllerVelocity = (transform.position - controllerPreviousPosition) * throwStrength / Time.deltaTime;
        controllerAngularVelocity = (transform.localRotation.eulerAngles - controllerPreviousRotation) * throwStrength / Time.deltaTime;
        controllerPreviousRotation = transform.localRotation.eulerAngles;
        controllerPreviousPosition = transform.position;
    }

    void SortList()
    {
        objectsInGrabRange = objectsInGrabRange.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            objectsInGrabRange.Add(other.gameObject.GetComponent<Rigidbody>());
            SortList();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody obj = other.gameObject.GetComponent<Rigidbody>();
        if (objectsInGrabRange.Contains(obj))
        {
            objectsInGrabRange.Remove(obj);
            SortList();
        }
    }

    void OnEnable()
    {
        if (thisHand.Equals(Hand.Left))
        {
            VRInteractionController.leftTrigger += Grab;
            //MockHMDInputManager.interactAction += Grab;
        }
        else
        {
            VRInteractionController.rightTrigger += Grab;
            //MockHMDInputManager.interactAction += Grab;
        }
    }

    void Grab(float value)
    {
        if (value == 1 && objectsInGrabRange.Count > 0)
        {
            if (!joint.connectedBody)
            {
                heldObject = objectsInGrabRange[0];
                joint.connectedBody = heldObject;
            }
        }
        else if (heldObject)
        {
            joint.connectedBody = null;
            heldObject.velocity = controllerVelocity;
            heldObject.angularVelocity = controllerAngularVelocity;
            heldObject = null;
        }
    }

    void OnDisable()
    {
        if (thisHand.Equals(Hand.Left))
        {
            VRInteractionController.leftTrigger -= Grab;
            //MockHMDInputManager.interactAction -= Grab;
        }
        else
        {
            VRInteractionController.rightTrigger -= Grab;
            //MockHMDInputManager.interactAction -= Grab;
        }
    }
}
