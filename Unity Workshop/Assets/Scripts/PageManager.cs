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

    int previousPage;


    // Start is called before the first frame update
    void Start()
    {
        // Hide all the pages at the beginning of the application
        HideAllPages();
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
        // assign previous page the current page at the top since current
        // page will be changing in a few lines of code
        previousPage = currentPage;

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

        // Get the data from the page we just exited then hide it
        int data = pages[previousPage].OnExit();
        pages[previousPage].ShowPage(false);

        // Send the data we got from the previous page and
        // show the current page
        pages[currentPage].OnEnter(data);
        pages[currentPage].ShowPage(true);
    }

    /// <summary>
    /// This function hides all the pages in our pages list
    /// </summary>
    public void HideAllPages()
    {
        for(int i = 0; i < pages.Count; i++)
        {
            pages[i].ShowPage(false);
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}