using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You can think of event driven programing as publishers posting the status
// of their task to a bulletin board, and listeners waiting to see what is posted
// beofre they try to do their job.

// Publishers in this context are incharge of initaiting action to its
// subscribers. Publishers should not care how many subscribers they have.
public class Publisher : MonoBehaviour
{
    // the key word static menas for EVERY publisher that exists, they all
    // share this particular variable

    // Actions are the default type for delegates in c#
    public static event Action SpacePressed;

    // Update is called once per frame
    void Update()
    {
        // This is how you get keyboard input in unity
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // check if action is null before trying to invoke it
            if (SpacePressed != null)
            {
                SpacePressed.Invoke();
            }
        }
    }
}
