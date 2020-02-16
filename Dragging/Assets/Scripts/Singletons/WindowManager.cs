using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : GenericSingletonClass<WindowManager>
{
    public void Update()
    {
        //UpdateLayerOrderOfWindows();
        //WindowsCount = Windows.Count;
    }

    #region Window Logic
    [SerializeField]
    public LinkedList<GameObject> Windows;
    public int WindowsCount;
    public override void Awake()
    {
        base.Awake();
        Windows = new LinkedList<GameObject>();
    }
    // Adds the given GameObject to Windows if Windows does not contain the GameObject
    public void AddWindow(GameObject go)
    {
        if(!Windows.Contains(go))
        {
            Windows.AddFirst(go);
        }
        WindowsCount = Windows.Count;
        UpdateLayerOrderOfWindows();
    }

    // Removes the given GameObject from Windows if Windows does contain the GameObject
    public void RemoveWindow(GameObject go)
    {
        if(Windows.Contains(go))
        {
            Windows.Remove(go);
        }
        WindowsCount = Windows.Count;
    }
    
    // Moves the given GameObject to the front of the LinkedList Windows
    public void MoveToFront(GameObject go)
    {
        if(Windows.Contains(go))
        {
            LinkedListNode<GameObject> current = Windows.FindLast(go);
            Windows.Remove(current);
            Windows.AddFirst(current);
        }
        UpdateLayerOrderOfWindows();
    }

    // Goes through Windows and sets the order in the sorting group layer component to its negative index in Windows
    public void UpdateLayerOrderOfWindows()
    {
        int index = 0;
        foreach(GameObject go in Windows)
        {
            go.transform.position = new Vector3(go.transform.position.x , go.transform.position.y, index);
            //go.GetComponent<UnityEngine.Rendering.SortingGroup>().sortingOrder = -index;
            index++;
        }
    }
    #endregion


   
}
