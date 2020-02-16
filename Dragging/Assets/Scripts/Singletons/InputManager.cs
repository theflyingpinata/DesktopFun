using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : GenericSingletonClass<InputManager>
{
    #region Clicking Logic
    public RaycastHit2D hit;
    public Vector2 cursorPosition;
    public Vector2 prevCursorPosition;

    public BasicFunction currentBF; // The BF being clicked
    public BasicFunction heldBF; // The BF being held
    public BasicFunction prevClickedBF; // The previously clicked BF
    public BasicFunction prevHeldBF; // The previously held BF

    public Camera mainCam;

    public override void Awake()
    {
        base.Awake();
        // Set up BasicFunctions held
        currentBF = null;
        heldBF = null;
        prevClickedBF = null;
        prevHeldBF = null;
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
        hit = Physics2D.Raycast(cursorPosition, -Vector2.up);//, 100f, 8);
    }

    // Make the lastBF the currentBF and update currentBF
    public void UpdateCurrentBasicFunction()
    {
        currentBF = null;
        if (hit.collider)
        {
            currentBF = hit.collider.GetComponent<BasicFunction>();
        }
    }

    // Will check for clicker, held, and relased mouse states and Invoke the right delegates in the right BasicFunction scripts
    public void HandleMouseInput()
    {

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
    public void InvokeClick()
    {
        if (currentBF)
        {
            Debug.Log("we hit something captain!");
            currentBF.Click?.Invoke();

            prevClickedBF = currentBF;
            heldBF = currentBF;
        }
    }

    public void InvokeHeld()
    {
        if (heldBF)
        {
            //Debug.Log("we released something captain!");
            heldBF.Hold?.Invoke();
        }
    }
    public void InvokeRelease()
    {
        if (heldBF)
        {
            Debug.Log("we released something captain!");
            heldBF.Release?.Invoke();

            prevHeldBF = heldBF;
            heldBF = null;
        }
    }
    #endregion
}
