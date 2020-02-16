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
        }
    }
    public void StartDragging()
    {
        Debug.Log("Start Drag");
        selected = true;
        cursorDif = InputManager.Instance.cursorPosition;
        cursorDif -= ParentPos;
    }
    public void StopDragging()
    {
        Debug.Log("End Drag");
        selected = false;
    }
    public override void Awake()
    {
        base.Awake();
        base.Click += StartDragging;
        base.Release += StopDragging;
    }

}
