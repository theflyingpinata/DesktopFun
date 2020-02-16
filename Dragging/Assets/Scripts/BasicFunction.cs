using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A child call for the basic functions a part of a window can have
[RequireComponent(typeof(Collider2D))]
public class BasicFunction : MonoBehaviour
{
    #region Parent
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
    #endregion

    #region Clicking and Collider

    [SerializeField]
    private BoxCollider2D collider2d;
    public BoxCollider2D Collider
    {
        get
        {
            return collider2d;
        }
    }
    public virtual void Awake()
    {
        if(collider2d == null)
        {
            collider2d = gameObject.GetComponent<BoxCollider2D>();
        }
    }
    // Returns true if the hit collider is this BasicFunctions's
    public bool IsHit()
    {
        return collider2d == InputManager.Instance.hit.collider;
    }
    // Returns true if IsHit is true and the left mouse button was pressed down this frame but not last frame
    public bool IsClicked()
    {
        bool clicked = Input.GetMouseButtonDown(0) && IsHit();
        if (clicked)
        {
            WindowManager.Instance.MoveToFront(ParentGO);
        }
            return clicked;
    }
    // Returns true if
    public bool IsReleased()
    {
        return Input.GetMouseButtonUp(0);// || !IsHit();
    }
    #endregion

    // Some basic functions that can be used by any child class

    #region Closing
    // Destorys this scripts ParentGO
    public void CloseThis()
    {
        Debug.Log("Close This");
        GameObject.Destroy(ParentGO);
    }

    // Destorys the ParentGO of the given BasicFunction
    public void Close(BasicFunction bf)
    {
        Debug.Log("Close Basic Function");
        GameObject.Destroy(bf.ParentGO);
    }

    // TODO prompt
    // Destroys this scripts ParentGO after a prompt
    public void CloseThisPrompt()
    {
        Debug.Log("Prompt -");
        bool prompt = true;
        if (prompt = true)
        {
            CloseThis();
        }
    }
    // TODO prompt
    // Destorys the ParentGO of the given BasicFunction after a prompt
    public void ClosePrompt(BasicFunction bf)
    {
        Debug.Log("Prompt -");
        bool prompt = true;
        if (prompt = true)
        {
            Close(bf);
        }
    }
    #endregion

    #region Opening
    // Instiates a GameObject at the given Vector2 position
    public void OpenGOPosition(GameObject go, Vector2 position)
    {
        Debug.Log("Open GO Position");
        GameObject.Instantiate(go, position, Quaternion.identity);
    }
    // Instiates a GameObject at the cursor's current position in Vector2
    public void OpenGOCursor(GameObject go)
    {
        Debug.Log("Open GO Cursor");
        OpenGOPosition(go, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }


    #endregion

    #region Events
    public delegate void ClickHandler();
    public ClickHandler Click;
    public ClickHandler Hold;
    public ClickHandler Release;
    
    #endregion
}
