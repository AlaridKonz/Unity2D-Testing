using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midair : State {
    [SerializeField] protected GroundJump groundJump;
    [SerializeField] protected AirJump airJump;
    [SerializeField] protected Ascending ascending;
    [SerializeField] protected Falling falling;
    [SerializeField] protected Landing landing;

    // Triggers
    [SerializeField] protected AirAttack attack;
    [SerializeField] protected AirBlock block;
    [SerializeField] protected AirDodge dodge;

    private int maxAirJumps = 1;
    private int airJumpCounter = 0;

    public override void Enter() {
        base.Enter();
        airJumpCounter = 0;
        Set(groundJump, false, "Initial state");
    }

    public override void Continue() {
        if (trigger != null && !trigger.finished) { trigger.Continue(); return; } else trigger = null;
        if (substate.finished) {
            if (substate == groundJump || substate == airJump)
                Set(ascending, true, "finished jump impulse");
            else if (substate == ascending)
                Set(falling, true, "stopped ascending");
            else if (substate == falling)
                Set(landing, true, "touched ground");
            else if (substate == landing)
                finished = true;
        } else substate.Continue();
    }

    public override void FixedContinue() {
        if (trigger != null && !trigger.finished) { trigger.FixedContinue(); return; } else trigger = null;
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
        if (!canMove) return;
        core.body.velocity = new Vector2(horizontalMovement * core.movementSpeed * moveSpeedModifier, core.body.velocity.y);
    }

    public override void TryJump() {
        if (airJumpCounter >= maxAirJumps) return;
        Set(airJump, true, "jump while midair");
        airJumpCounter++;
    }

}