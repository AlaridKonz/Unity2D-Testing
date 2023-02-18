using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    protected State state;

    public void Set(State newState, bool force = false) {
        if (state != newState || force) {
            state.Exit();
            state = newState;
            newState.Setup(this);
            newState.Enter();
        }
    }

}

