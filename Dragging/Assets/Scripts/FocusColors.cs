using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="FocusColors")]
public class FocusColors : ScriptableObject
{
    #region Highlighting
    [Header("Colors")]
    public Color Normal = Color.white;
    public Color Hover = Color.white;
    public Color Pressed = Color.white;
    public Color Disabled = Color.white;
    #endregion
}
