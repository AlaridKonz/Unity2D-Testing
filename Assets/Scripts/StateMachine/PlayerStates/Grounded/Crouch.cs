using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : State {

    public override void Enter() {
        base.Enter();
        if (core != null)
            SetFirstFrame();
    }

    public override void TryMovement(float horizontalMovement, float verticalInput) {
        if (verticalInput > -0.8f) finished = true;
    }

}