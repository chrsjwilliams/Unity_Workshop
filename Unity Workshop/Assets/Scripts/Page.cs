using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is the parent class for all pages in our application
/// (i.e. Welcome Page, Counter Page, Object Page)
/// </summary>
public class Page : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// This function should be called when we show a page
    ///
    /// For not we are passing in an integret value to
    /// update the number of Draggable UI Elements on the
    /// Objects page.
    /// 
    /// </summary>
    public virtual void OnEnter(int numberOfObjects)
    {
        
    }

    ///
    /// Functions and return types:
    ///     Every function must indicate what they return.
    ///     In many cases we don't want an output value for our function,
    ///     so it's return type is "void." in the case of our OnExit function
    ///     or a function like CheckIfLoggedIn, we want to be given back a
    ///     value so we can use the output of that function to infrom how our
    ///     application should operate.
    ///
    
    /// <summary>
    /// This function should be called when we stop show a page
    ///
    /// This function returns a value that is then passed into
    /// the next page's OnEnter function
    /// 
    /// </summary>
    public virtual int OnExit()
    {
        // we return int.MinValue to let us know if a page
        // has not yet implemented its own OnExit function
        return int.MinValue;
    }

    /// <summary>
    /// This fucntion was moved from our Page Maanger. This controls
    /// how a pageappears and disappears
    /// </summary>
    /// <param name="show"></param>
    public void ShowPage(bool show)
    {
        if(show)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
