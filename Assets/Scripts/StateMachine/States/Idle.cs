using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State {

    public override void Continue() {
        frameCounter++;
        if (hasNotReachedFrameRateTime) return;
        PlayNextFrame();
        CycleSpriteIndex();
    }

}

public class InputManager : MonoBehaviour {
    // input down
    // input
    // input up

    // any valid input
}