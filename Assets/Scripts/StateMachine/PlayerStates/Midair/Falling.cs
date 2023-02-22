using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : State {

    public override void Enter() {
        base.Enter();
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

    public override bool ShouldExit() {
        return core.body.velocity.y >= -0.1f;
    }
}
