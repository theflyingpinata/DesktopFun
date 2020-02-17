using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlipActive : BasicFunction
{
    public BasicFunction bf;

    public override void Awake()
    {
        base.Awake();
        base.Release += FlipActive;
    }

    public void FlipActive()
    {
        bf.SetActive(!bf.Active);
    }
}
