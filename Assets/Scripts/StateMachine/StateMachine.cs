using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {
    [SerializeField] protected State substate;
    [SerializeField] protected State trigger;

    public void Set(State newState, bool force = false, string reason = "") {
        if (substate != newState || force) {
            if (substate != null)
                substate.Exit(reason);
            substate = newState;
            newState.Setup(this);
            newState.Enter();
        }
    }

    public void Trigger(State newTrigger, bool force = false, string reason = "") {
        // check for correct cancel-frames

        if (trigger != newTrigger || force) {
            if (trigger != null)
                trigger.Exit(reason);
            trigger = newTrigger;
            newTrigger.Setup(this);
            newTrigger.Enter();
        }
    }

}

