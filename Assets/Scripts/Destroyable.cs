using UnityEngine;
using System.Collections;
using System;

public abstract class Destroyable : MonoBehaviour
{
    private bool kOnScreen = false;

    void Start()
    {

    }

    public virtual void FixedUpdate()
    {
        Renderer renderer = base.GetComponent<Renderer>();
        if (renderer.isVisible)
        {
            kOnScreen = true;
        }
        else
        {
            if (kOnScreen)
                Destroy();
        }
    }

    public bool IsOnScreen
    {
        get
        {
            return this.GetComponent<Renderer>().isVisible;
        }
    }

    public virtual bool CanBeDamaged
    {
        get
        {
            return this.IsOnScreen;
        }
    }


    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
