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
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            // Instantiate is a function that creates a new GameObject. In
            // this scenario we create a new draggableUIPrefab and make its
            // parent the objectHolder GameObject so that it is a child of
            // that page in the heierarchy. 
            UIDragger newDraggable = Instantiate(draggableUIPrefab, objectHolder);
            draggableUIElements.Add(newDraggable);
        }
        
    }

    public void OnEnter(int numOfObjects)
    {
        if (numOfObjects < 0)
        {
            Debug.LogError("Negative Value given for numOfObjects");
            return;
        }


        if (numOfObjects == draggableUIElements.Count)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
