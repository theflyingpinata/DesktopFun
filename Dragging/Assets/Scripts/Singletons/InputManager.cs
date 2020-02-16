using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    #region Clicking Logic
    public RaycastHit2D hit;
    public Vector2 cursorPosition;
    public void Update()
    {
        UpdateClickLogic();
    }
    public void UpdateClickLogic()
    {
        cursorPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(cursorPosition, -Vector2.up);//, 100f, 8);
    }
    #endregion
}
