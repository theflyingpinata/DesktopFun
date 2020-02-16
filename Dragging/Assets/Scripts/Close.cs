using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : BasicFunction
{
    public void OnMouseOver()
    {
        if (IsClicked())
        {
            CloseThis();
        }
    }
    
    
    // Destroyes the Parent without warning
    public virtual void CloseWindow()
    {
        Debug.Log("Close");
        GameObject.Destroy(ParentGO);
    }
}
