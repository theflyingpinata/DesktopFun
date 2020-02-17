using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    #region Clicking Logic
    public RaycastHit2D hit;
    public Vector2 cursorPosition;
    public Vector2 prevCursorPosition;

    // Last is before current
    // Prev is previous frame
    public BasicFunction hoverBF; // The BF that the mouse is over
    public BasicFunction prevHoverBF; // The BF that the mouse is over last frame
    public BasicFunction currentBF; // The BF being clicked
    public BasicFunction heldBF; // The BF being held
    public BasicFunction lastClickedBF; // The last clicked BF
    public BasicFunction lastHeldBF; // The last held BF

    public Camera mainCam;

    public override void Awake()
    {
        base.Awake();
        // Set up BasicFunctions held
        hoverBF = null;
        currentBF = null;
        heldBF = null;
        lastClickedBF = null;
        lastHeldBF = null;
        mainCam = Camera.main;
    }

    public void Update()
    {
        UpdateMouseInfo();
        UpdateCurrentBasicFunction();
        HandleMouseInput();
    }
    
    // Update InputManager's cursor position and raycast
    public void UpdateMouseInfo()
    {
        prevCursorPosition = cursorPosition;
        //Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        cursorPosition = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(cursorPosition, Vector2.zero);//, 100f, 8);
    }

    // Make the lastBF the currentBF and update currentBF
    public void UpdateCurrentBasicFunction()
    {
        prevHoverBF = hoverBF;
        hoverBF = null;

        if (hit.collider)
        {
            hoverBF = hit.collider.GetComponent<BasicFunction>();
        }
        else
        {
            currentBF = null;
        }
    }

    // Will check for clicker, held, and relased mouse states and Invoke the right delegates in the right BasicFunction scripts
    public void HandleMouseInput()
    {
        InvokeExit();
        InvokeEnter();
        InvokeHover();
        if (Input.GetMouseButtonDown(0))
        {
            InvokeClick();
        }

        if(Input.GetMouseButton(0))
        {
            InvokeHeld();
        }

        if (Input.GetMouseButtonUp(0))
        {
            InvokeRelease();
        }

        
    }

    public void InvokeEnter()
    {
        if(hoverBF && hoverBF != prevHoverBF  && hoverBF.Active)
        {
            hoverBF.Enter?.Invoke();
        }
    }
    public void InvokeExit()
    {
        if (prevHoverBF && prevHoverBF != hoverBF && prevHoverBF.Active)
        {
            prevHoverBF.Exit?.Invoke();
        }
    }
    public void InvokeHover()
    {
        if(hoverBF && hoverBF.Active)
        {
            hoverBF.Hover?.Invoke();
        }
    }
    public void InvokeClick()
    {
        if (hoverBF && hoverBF.Active)
        {
            currentBF = hoverBF;
            Debug.Log("we hit something captain!");
            currentBF.Press?.Invoke();

            lastClickedBF = currentBF;
            heldBF = currentBF;
        }
    }

    public void InvokeHeld()
    {
        if (heldBF && heldBF.Active)
        {
            //Debug.Log("we released something captain!");
            heldBF.Hold?.Invoke();
        }
    }

    public void InvokeRelease()
    {
        if (currentBF && hoverBF.Active)
        {
            Debug.Log("we released something captain!");
            currentBF.Release?.Invoke();

        }
        if (hoverBF && hoverBF.Active)
        {
            lastHeldBF = heldBF;
            heldBF = null;
        }
    }
    #endregion
}
