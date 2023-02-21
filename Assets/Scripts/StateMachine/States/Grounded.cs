using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State {
    [SerializeField] protected Walk walk;
    [SerializeField] protected Run run;
    [SerializeField] protected Idle idle;
    [SerializeField] protected Crouch crouch;
    [SerializeField] protected Attack attack;
    State defaultSubState;

    private void Awake() {
        defaultSubState = idle;
        substate = defaultSubState;
        Debug.Log("hey");
    }

    public override void Continue() {
        if (!substate.finished)
            substate.Continue();
        else
            Set(idle, false, "finished last state");
    }

    public override void TryAttack() {
        if (substate == attack) return;
        Set(attack, true, "attack");
    }

}