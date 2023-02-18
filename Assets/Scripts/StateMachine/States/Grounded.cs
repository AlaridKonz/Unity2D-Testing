using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State {
    [SerializeField] Walk walk;
    [SerializeField] Run run;
    [SerializeField] Idle idle;
    [SerializeField] Crouch crouch;
    [SerializeField] Attack attack;
    State defaultSubState;

    private void Awake() {
        defaultSubState = idle;
        substate = defaultSubState;
        Debug.Log("hey");
    }

    public override void Continue() {
        substate.Continue();
    }

}