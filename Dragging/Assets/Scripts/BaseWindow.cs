using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWindow : MonoBehaviour
{
    public List<BasicFunction> functions;

    public void Awake()
    {
        SetFunctionsParent();
        WindowManager.Instance.AddWindow(gameObject);
    }
    public void OnDisable()
    {
        WindowManager.Instance.RemoveWindow(gameObject);
    }

    public void SetFunctionsParent()
    {
        foreach (BasicFunction bf in functions)
        {
            bf.Parent = this;
        }
    }
}
