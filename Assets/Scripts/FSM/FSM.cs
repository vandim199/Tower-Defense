using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FSM : MonoBehaviour
{
    public static FSM fsm;

    public State CurrentState;

    public Dictionary<Type, State> states = new Dictionary<Type, State>();
    
    // Start is called before the first frame update
    void Start()
    {
        if(fsm == null) fsm = this;
        else Destroy(this);
    }

    public bool CheckState<T>() where T : State
    {
        Type type = typeof(T);

        if(CurrentState.GetType() == type) return true;
        else return false;
    }

    public State GetState<T>() where T : State
    {
        Type type = typeof(T);
        State state;

        if(states.ContainsKey(type))
        {
            state = states[type];
            if(type.ToString()=="BuildState") return state as BuildState;
            else if(type.ToString()=="SelectionState") return state as SelectionState;
            else return null;
        }
        else return null;
    }

    public void ChangeState<T>() where T : State
    {
        ChangeState(typeof(T));
    }

    public void ChangeState(Type type)
    {
		if (CurrentState != null && CurrentState.GetType() == type) return;

        if(CurrentState != null)
        {
            CurrentState.ExitState();
            CurrentState = null;
        }
        
        if(states.ContainsKey(type))
        {
            CurrentState = states[type];
            CurrentState.EnterState();
        }
        
    }
}
