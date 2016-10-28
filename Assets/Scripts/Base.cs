using UnityEngine;
using System.Collections;

public abstract class Base
{
    protected UI kUI;
    protected Logic kLogic;
    protected Map kMap;
    protected Board kBoard;

    public Base()
    {

    }

    public void Setup(UI kUI, Logic kLogic, Map kMap, Board kBoard)
    {
        this.kUI = kUI;
        this.kLogic = kLogic;
        this.kMap = kMap;
        this.kBoard = kBoard;
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }
}
