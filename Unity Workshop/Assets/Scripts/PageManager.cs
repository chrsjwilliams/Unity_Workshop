using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to mange which page get displayed. It uses the CanvasGroup
/// component and Lists to show and hide lists
/// </summary>
public class PageManager : MonoBehaviour
{
    // We store our Pages in a list so we can iterate over them and preform
    // group operations easily.
    public List<Page> pages;

    // stores the current index of the page being dislpayed.
    // The first pags is index 0 and the last page is index Count - 1
    int currentPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Shows the first page when the application starts.
        ShowPageIndex(0);
    }

    /// <summary>
    /// Controls which page should be shown. This function is referenced on the
    /// Forward and Back Buttons in the Unity Heirarchy
    /// </summary>
    /// <param name="i">This is the value we ad to our index. We add 1 or -1 to
    /// move forward or backward  one page at a time.</param>
    public void ShowPageIndex(int i)
    {
        //  Add th incoming value to our curent page index
        currentPage = currentPage + i;

        //  If we try to go too far back, we set our current page to our first page
        if(currentPage  <= 0)
        {
            currentPage = 0;
        }

        //  If we try to go too far forward we set our current page to the last page
        if(currentPage >= pages.Count - 1)
        {
            currentPage = pages.Count - 1;
        }

        // This is a for loop.
        // It is made up of three parts.
        //      1.  Initializing the looping variable:  int j = 0
        //      2.  Setting loop condition:             j < pages.Count
        //      3.  Command to execute after loop:      j++

        // Here we loop over every page, if the index is equal to our current page,
        // Then we show that page, otherwise we hide that page.
        for(int j = 0; j < pages.Count; j++)
        {
            if(j == currentPage)
            {
                pages[j].ShowPage(true);
            }
            else
            {
                pages[j].ShowPage(false);
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}