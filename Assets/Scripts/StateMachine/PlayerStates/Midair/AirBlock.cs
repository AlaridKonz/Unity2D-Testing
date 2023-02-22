using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlock : State {

    public override void Enter() {
        base.Enter();
    }

    public override void Continue() {
        timeSinceLastUpdate += Time.deltaTime;
        if (!isTimeToUpdate && frameCounter != 0) return;
        PlayNextFrame();
        NextSpriteIndex();
        // ShouldExit();
        frameCounter++;
        timeSinceLastUpdate = 0;
    }
}