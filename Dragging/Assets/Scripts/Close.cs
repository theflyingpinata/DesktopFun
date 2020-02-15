using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : BasicFunction
{
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CloseWindow();
        }
    }
    
    // Destroyes the Parent without warning
    public virtual void CloseWindow()
    {
        Debug.Log("Close");
        GameObject.Destroy(ParentGO);
    }
}
