using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    #region Singleton
    private static WindowManager instance;

    public static WindowManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("WindowManager");
                go.AddComponent<WindowManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        LateAwake();
    }
    #endregion

    public List<GameObject> Windows;
    private void LateAwake()
    {
        Windows = new List<GameObject>();
    }
    // Adds the given GameObject to Windows if Windows does not contain the GameObject
    public void AddWindow(GameObject go)
    {
        if(!Windows.Contains(go))
        {
            Windows.Add(go);
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
}
