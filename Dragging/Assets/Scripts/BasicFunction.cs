using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A child call for the basic functions a part of a window can have
public class BasicFunction : MonoBehaviour
{
    [SerializeField]
    private BaseWindow parent;

    public BaseWindow Parent
    {
        get
        {
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return null;
            }
        }
        set
        {
            parent = value;
        }
    }
    public GameObject ParentGO
    {
        get
        {
            return Parent.gameObject;
        }
    }
    public Vector2 ParentPos
    {
        get
        {
            return ParentGO.transform.position;
        }
        set
        {
            ParentGO.transform.position = value;
        }
    }
}
