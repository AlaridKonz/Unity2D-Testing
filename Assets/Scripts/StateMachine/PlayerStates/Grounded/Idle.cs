using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State {

    public override void Enter() {
        base.Enter();
        framerate = 2;
    }

    public override void Continue() {
        timeSinceLastUpdate += Time.deltaTime;
        if (!isTimeToUpdate && frameCounter != 0) return;
        PlayNextFrame();
        CycleSpriteIndex();
        // ShouldExit();
        frameCounter++;
        timeSinceLastUpdate = 0;
    }
}
