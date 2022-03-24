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
    /// </summary>
    public void OnEnter()
    {
        
    }

    /// <summary>
    /// This function should be called when we stop show a page
    /// </summary>
    public void OnExit()
    {
        
    }

    /// <summary>
    /// This fucntionwas moved from our Page Maanger. This controls
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
