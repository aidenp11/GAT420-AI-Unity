using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();
    public AIState currentState { get; private set; }

    public void Update()
    {
        if (currentState == null)
        {
            currentState?.OnUpdate();
        }
    }

    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name);
        
        states[name] = state;
    }

    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "State machine does not contain state" + name);

        var newState = states[name];

        if (newState == currentState) return;

        //exit current state
        currentState?.OnExit();
        //set new state
        currentState = newState;
        //enter new state
        currentState?.OnEnter();
    }
}
