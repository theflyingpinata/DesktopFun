using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAtCursor : BasicFunction
{
    public GameObject toOpenWindow;

    public void OnMouseOver()
    {
        //Debug.Log("pleaseas sasdhow up");
        if (IsClicked())
        //if (Input.GetMouseButtonDown(0))
        {
            OpenWindow();
        }
        
    }
    public void OpenWindow()
    {
        Debug.Log("Open Window");
        OpenGOCursor(toOpenWindow);// GameObject.Instantiate(toOpenWindow, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
