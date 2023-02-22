using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPlayerState : State {
    [SerializeField] protected Grounded grounded;
    [SerializeField] protected Midair midair;

    public override void Enter() {
        base.Enter();
        Set(grounded, false, "Initial state");
    }

    public override void Continue() {
        if (!substate.finished)
            substate.Continue();
        else
            Set(grounded, false, "finished last state");
    }

    public override void FixedContinue() {
        substate.FixedContinue();
    }

    public override void TryJump() {
        if (!canJump) return;
        if (substate == grounded) {
            Set(midair, false, "jumped");
            return;
        }
        if (substate == midair) {
            substate.TryJump();
            return;
        }
    }

}