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
            //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ParentPos = InputManager.Instance.cursorPosition - cursorDif;
            if(IsReleased())
            {
                Debug.Log("End Drag");
                selected = false;
            }
        }
    }

    public void OnMouseOver()
    {
        if(IsClicked())
        {
            Debug.Log("Start Drag");
            selected = true;
            cursorDif = InputManager.Instance.cursorPosition;
            cursorDif -= ParentPos;
        }
    }
}
