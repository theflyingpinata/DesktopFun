using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Open : BasicFunction
{
    public GameObject toOpenWindow;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            OpenWindow();
        }
    }

    // Should open a window
    public virtual void OpenWindow()
    {
        Debug.Log("Open");
    }

}
