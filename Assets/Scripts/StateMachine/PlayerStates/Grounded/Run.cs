using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State {

    public override void Enter() {
        base.Enter();
        framerate = 15;
    }

    public override void Continue() {
        timeSinceLastUpdate += Time.deltaTime;
        if (!isTimeToUpdate && frameCounter != 0) return;
        PlayNextFrame();
        CycleSpriteIndex();
        frameCounter++;
        timeSinceLastUpdate = 0;

        if (ShouldExit()) finished = true;
    }

    public override void FixedContinue() {
        core.body.velocity = new Vector2(core.horizontalMovement * core.movementSpeed * moveSpeedModifier, core.body.velocity.y);
    }

    public override bool ShouldExit() {
        return Mathf.Abs(core.horizontalMovement) < 0.1f;
    }

}