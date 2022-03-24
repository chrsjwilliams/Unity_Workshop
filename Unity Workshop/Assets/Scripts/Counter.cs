using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This Counter class updates a text field and locks the displayed value between
/// a min and a max value.
///
/// If you are opening this scene in a new Unity project, you will need
/// to import images for your up button and your down button
/// 
/// </summary>
// All our Pages are children of the Page class allow us access to any
// functions or variables that are either marked public or protected.
public class Counter : Page
{
    public Button upButton;
    public Button downButton;

    [SerializeField] TextMeshProUGUI counter;
    [SerializeField] int maxValue;
    [SerializeField] int minValue;

    int value = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the text at the beginning of the application
        counter.text = "Welcome! Press a button!";
    }

    public void UpdateCounter(int i)
    {
        // assigns value based on incoming input
        value = value + i;

        // Checks if we are larger than the max value
        if(value >= maxValue)
        {
            value = maxValue;
            upButton.interactable = false;
        }
        else
        {
            // makes up button interactable if we are not at the max value
            upButton.interactable = true;
        }

        // Checks if we are smaller than the min value
        if(value <= minValue)
        {
            value = minValue;
            downButton.interactable = false;
        }
        else
        {
            // makes down button interactable if we are not smaller than the min value
            downButton.interactable = true;
        }

        // Updates the text
        if (value == 1)
        {
            counter.text = value + " click";
        }
        else
        {
            counter.text = value + " clicks";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
