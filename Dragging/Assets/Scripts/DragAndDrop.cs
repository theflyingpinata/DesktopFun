using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : BasicFunction
{
    private Vector2 cursorDif;
    private bool selected;


    public void Update()
    {
        if(selected)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ParentPos = cursorPos - cursorDif;
            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("End Drag");
                selected = false;
            }
        }
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start Drag");
            selected = true;
            cursorDif = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorDif -= ParentPos;
        }
    }
}
