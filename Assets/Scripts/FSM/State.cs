using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public void Update()
    {
        if(gameObject.active)
        {
            Mouse();
            OnClick();
        }
    }

    public void EnterState()
    {
        gameObject.SetActive(true);
    }

    public void ExitState()
    {
        gameObject.SetActive(false);
    }

    public State GetState()
    {
        return this;
    }

    public abstract void Mouse();

    public abstract void OnClick();
}