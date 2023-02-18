using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State {

    public override void Continue() {
        frameCounter++;
        if (hasNotReachedFrameRateTime) return;
        PlayNextFrame();
        CycleSpriteIndex();
    }

}