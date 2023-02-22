using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State {

    public override void Enter() {
        base.Enter();
        framerate = 10;
        moveSpeedModifier = 0.5f;
    }

    public override void Continue() {
        timeSinceLastUpdate += Time.deltaTime;
        if (!isTimeToUpdate && frameCounter != 0) return;
        PlayNextFrame();
        NextSpriteIndex();
        frameCounter++;
        timeSinceLastUpdate = 0;
    }

}