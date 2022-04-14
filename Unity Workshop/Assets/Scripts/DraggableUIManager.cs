using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All our Pages are children of the Page class allow us access to any
// functions or variables that are either marked public or protected.
public class DraggableUIManager : Page
{
    [SerializeField] List<UIDragger> draggableUIElements = new List<UIDragger>();
    [SerializeField] RectTransform objectHolder;
    [SerializeField] UIDragger draggableUIPrefab;

    [SerializeField] int thingsToMake = 0;

    // Start is called before the first frame update
    void Start()
    {
        Counter.ValueChanged += OnValueChanged;
    }

    private void OnDestroy()
    {
        Counter.ValueChanged -= OnValueChanged;
    }


    public void OnValueChanged(int value)
    {
        thingsToMake = value;
    }

    public override void OnEnter(int numOfObjects)
    {
        if (thingsToMake < 0)
        {
            Debug.LogError("Negative Value given for numOfObjects");
            return;
        }

        // if the value we are given is the same as the number of
        // objects in our list, exit the function early
        if(thingsToMake == draggableUIElements.Count)
        {
            return;
        }

        // find the difference between the data passed in and the number
        // of objects we have in our list
        int difference = thingsToMake - draggableUIElements.Count;

        // if difference is positive, we need to make more draggable ui elements
        // if difference is negative, we need to remove draggable ui elements

        if (difference > 0)
        {
            // We need to make more draggable UI elements
            for (int i = 0; i < difference; i++)
            {
                // Instantiate is a function that creates a new GameObject. In
                // this scenario we create a new draggableUIPrefab and make its
                // parent the objectHolder GameObject so that it is a child of
                // that page in the heierarchy. 
                UIDragger newDraggable = Instantiate(draggableUIPrefab, objectHolder);
                draggableUIElements.Add(newDraggable);
            }
        }
        else
        {
            // create a list of elements to delete
            List<UIDragger> elementsToDelete = new List<UIDragger>();
            for(int i = 0; i < Mathf.Abs(difference); i++)
            {
                elementsToDelete.Add(draggableUIElements[i]);
            }

            foreach(UIDragger element in elementsToDelete)
            {
                // remove element form the list before destroying it
                draggableUIElements.Remove(element);
                Destroy(element.gameObject);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
