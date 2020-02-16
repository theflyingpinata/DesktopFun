using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : GenericSingletonClass<WindowManager>
{
    /*
    #region Singleto
    private static WindowManager _instance;

    public static WindowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WindowManager>();

                if (_instance == null)
                {
                    GameObject go = new GameObject("WindowManager");
                    _instance = go.AddComponent<WindowManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        LateAwake();
    }
    #endregion

    */
    public void Update()
    {
        UpdateLayerOrderOfWindows();
        WindowsCount = Windows.Count;
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
    }

    // Removes the given GameObject from Windows if Windows does contain the GameObject
    public void RemoveWindow(GameObject go)
    {
        if(Windows.Contains(go))
        {
            Windows.Remove(go);
        }
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
