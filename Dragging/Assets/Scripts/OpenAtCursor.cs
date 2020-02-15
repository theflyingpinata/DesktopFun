using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAtCursor : Open
{
    public override void OpenWindow()
    {
        base.OpenWindow();
        GameObject.Instantiate(toOpenWindow, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
