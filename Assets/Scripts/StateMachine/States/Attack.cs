using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State {

    public override void Enter() {
        Debug.Log("attack");
        framerate = 30;
    }

    public override void Continue() {
        frameCounter++;
        if (hasNotReachedFrameRateTime) return;
        PlayNextFrame();
        NextSpriteIndex();
    }

}