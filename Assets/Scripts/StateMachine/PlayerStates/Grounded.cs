using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : State {
    [SerializeField] protected Walk walk;
    [SerializeField] protected Run run;
    [SerializeField] protected Idle idle;
    [SerializeField] protected Crouch crouch;

    // Triggers
    [SerializeField] protected Attack attack;
    [SerializeField] protected Block block;
    [SerializeField] protected Dodge dodge;


    public override void Enter() {
        base.Enter();
        Set(idle, false, "Initial state");
    }

    public override void Continue() {
        if (trigger != null && !trigger.finished) { trigger.Continue(); return; } else ClearTrigger();
        if (!substate.finished)
            substate.Continue();
        else
            Set(idle, false, "finished last state");
    }

    public override void FixedContinue() {
        if (trigger != null && !trigger.finished) { trigger.FixedContinue(); return; } else ClearTrigger();
        substate.FixedContinue();
    }

    public override void TryAttack() {
        if (!canAttack) return;
        Try(attack);
    }

    public override void TryBlock() {
        Try(block);
    }

    public override void TryDodge() {
        Try(dodge);
    }

    private void Try(State newTrigger) {
        if (trigger != null || stayPassive) return;
        Trigger(newTrigger, true);
    }

    public override void TryMovement(float horizontalMovement) {
        if (Mathf.Abs(horizontalMovement) < 0.1f) return;
        if (Mathf.Abs(horizontalMovement) < 0.6f) Set(walk, false, "slow movement");
        else Set(run, false, "fast movement");
    }

    // public override bool ShouldExit() {
    //     return core.jumped;
    // }

}