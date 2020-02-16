using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringToFront : BasicFunction
{
    
    public void OnMouseOver()
    {
        if (IsClicked())
        {
            WindowManager.Instance.MoveToFront(gameObject);
        }
    }
    
}
