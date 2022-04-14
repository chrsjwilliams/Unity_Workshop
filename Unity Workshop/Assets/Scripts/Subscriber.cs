using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Subscribers are the other side of Event Driven PRogramming.
// They wait until their subscriton has been posted before doing their task
public class Subscriber : MonoBehaviour
{
    // We can place set other functions to be called in the Inspector by using the
    // UnityEvent data type
    public UnityEvent SubscriberEvent;

    // Start is called before the first frame update
    void Start()
    {
        // we subscribe to events using the += operator
        Publisher.SpacePressed += OnSpacePressed;
    }

    private void OnDestroy()
    {
        // we unsubscribe to events using the += operator
        Publisher.SpacePressed -= OnSpacePressed;
    }

    public void OnSpacePressed()
    {
        Debug.Log("Space was pressed! " + gameObject.name);
        if(SubscriberEvent != null)
        {
            // calls the Unity event of our subscriber
            SubscriberEvent.Invoke();
        }
    }
}
