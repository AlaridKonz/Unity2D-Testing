using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    protected State substate;

    public void Set(State newState, bool force = false, string reason = "") {
        if (substate != newState || force) {
            substate.Exit(reason);
            substate = newState;
            newState.Setup(this);
            newState.Enter();
        }
    }

}

