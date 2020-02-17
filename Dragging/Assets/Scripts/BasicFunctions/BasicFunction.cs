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
        if (collider2d == null)
        {
            collider2d = gameObject.GetComponent<BoxCollider2D>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }
        Press += Activate;

        // Changing color

        // I Don't want to make this invidual methods but I might :/
        Press += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Pressed); } });
        Release += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Normal); } });
        Enter += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Hover); } });
        Exit += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Normal); } });

        Enable += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Normal); } });
        Disable += new ClickHandler(() => { if (focusColors) { ChangeSpriteColor(focusColors.Disabled); } });

    }
    public void Activate()
    {
        WindowManager.Instance.MoveToFront(ParentGO);
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
    public ClickHandler Press;
    public ClickHandler Hold;
    public ClickHandler Release;
    public ClickHandler Enter;
    public ClickHandler Exit;
    public ClickHandler Hover;

    public ClickHandler Enable;
    public ClickHandler Disable;

    #endregion

    #region Coloring
    public FocusColors focusColors;
    public SpriteRenderer spriteRenderer;

    public void ChangeSpriteColor(Color color)
    {
        //Debug.Log("This part works");
        if (spriteRenderer)
        {
            spriteRenderer.color = color;
        }
    }
    #endregion

    #region Active logic
    [SerializeField]
    private bool active = true;
    public bool Active
    {
        get
        {
            return active;
        }
    }

    // Checks if given bool is different from active. If it is, it sets active to the given bool and calls the correct delegate, either Enable or Disable
    public void SetActive(bool newActive)
    {
        if(active != newActive)
        {
            active = newActive;
            if (newActive)
            {
                Enable?.Invoke();
            }
            else
            {
                Disable?.Invoke();
            }
        }
    }
    #endregion
}
