using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBlock : State {

    private float gravityBackup;
    private float minimumTime;

    public override void Enter() {
        base.Enter();
        gravityBackup = core != null ? core.body.gravityScale : 3f;
        canMove = false;
        if (core != null) {
            core.body.velocity = Vector2.zero;
            core.body.gravityScale = 0;
        }
        minimumTime = 0.5f;
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

    public override void NextSpriteIndex() {
        if (spriteIndex < spriteSheet.sprites.Length - 1) spriteIndex++;
        else if (time >= minimumTime) finished = true;
    }

    public override void Exit(string reason) {
        core.body.gravityScale = gravityBackup;
        base.Exit(reason);
    }

}
