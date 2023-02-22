using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDodge : State {
    private float minimumTime;
    private float stoppingTime;
    private float gravityBackup;

    public override void Enter() {
        base.Enter();
        moveSpeedModifier = 1.7f;
        minimumTime = 0.5f;
        stoppingTime = 0.4f;
        gravityBackup = core != null ? core.body.gravityScale : 3f;
        if (core != null)
            core.body.gravityScale = 0;


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

    public override void FixedContinue() {
        if (time < stoppingTime)
            core.body.velocity = new Vector2(core.movementSpeed * core.facingDirection * moveSpeedModifier, 0);
        else
            core.body.velocity = new Vector2(core.movementSpeed * core.facingDirection, 0);
    }

    public override void CycleSpriteIndex() {
        if (spriteIndex < spriteSheet.sprites.Length - 1) spriteIndex++;
        else spriteIndex = 0;
        if (time >= minimumTime) finished = true;
    }

    public override void Exit(string reason) {
        core.body.gravityScale = gravityBackup;
        base.Exit(reason);
    }
}
