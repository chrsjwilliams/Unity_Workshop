using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This class can be attached to any UI component making it draggable on screen.
/// It inherits from EventTrigger instead of MonoBehavior to give us access to
/// Unity Events for OnPointerDown, OnPointerUp, and others.
/// </summary>
public class UIDragger : EventTrigger
{

    // Sets if the gameObject is selectable. At the start of the application,
    // no object is selected
    bool isSelected = false;

    // This event occurs when the user toushes down either using their cursor or
    // when we touch the object
    public override void OnPointerDown(PointerEventData eventData)
    {
        // base.OnPointerDown(eventData runs the command of the inherited function
        // OnPointerDown function
        base.OnPointerDown(eventData);
        // If we touch the object, it has been selected
        isSelected = true;
    }

    // This event occurs when the user releases their toush either using their cursor or
    // with thier finger
    public override void OnPointerUp(PointerEventData eventData)
    {
        // base.OnPointerUp(eventData runs the command of the inherited function
        // OnPointerDown function
        base.OnPointerUp(eventData);
        // If we release the object we are no longer selected
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the obkect is selected then we can move it
        if(isSelected)
        {
            // each gameObject has a transfrom, from the transform we can change its position
            // We use Input.mousePosiiton to get the new posiiton of the object.
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
