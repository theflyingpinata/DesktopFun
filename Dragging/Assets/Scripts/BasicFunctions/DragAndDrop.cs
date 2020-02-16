using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : BasicFunction
{
    [SerializeField]
    private Vector2 cursorDif; // Differenc between anchor and initial cursor position
    [SerializeField]
    private Vector2 estimatedCursorSpeed;

    public void StartDragging()
    {
        Debug.Log("Start Drag");
        cursorDif = InputManager.Instance.cursorPosition;
        cursorDif -= ParentPos;
    }

    public void Drag()
    {
        ParentPos = InputManager.Instance.cursorPosition - cursorDif;
        /*
        estimatedCursorSpeed = InputManager.Instance.cursorPosition - InputManager.Instance.prevCursorPosition;
        ParentPos += estimatedCursorSpeed;
        */
    }

    public void StopDragging()
    {
        Debug.Log("End Drag");
    }

    public override void Awake()
    {
        base.Awake();
        base.Click += StartDragging;
        base.Hold += Drag;
        base.Release += StopDragging;
    }

}
