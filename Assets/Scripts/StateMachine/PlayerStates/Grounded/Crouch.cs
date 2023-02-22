using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : State {

    public override void Continue() {
        frameCounter++;
        if (hasNotReachedFrameRateTime) return;
        PlayNextFrame();
        CycleSpriteIndex();
    }

}