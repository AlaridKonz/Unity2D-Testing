using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State {

    public override void Continue() {
        frameCounter++;
        if (hasNotReachedFrameRateTime) return;
        PlayNextFrame();
        CycleSpriteIndex();
    }

}