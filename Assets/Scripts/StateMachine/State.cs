using UnityEngine;

public class State : StateMachine {
    protected Character core;
    protected StateMachine parent;
    // protected State substate;

    [SerializeField] protected int framerate = 10;
    [SerializeField] protected SpriteSheet spriteSheet;
    protected int spriteIndex = 0;
    protected int frameCounter = 0;
    protected int framesSinceSpriteUpdate = 0;
    protected float startTime;
    protected float time => Time.time - startTime;
    protected bool hasNotReachedFrameRateTime => framesSinceSpriteUpdate++ < framerate;
    public bool finished { get; private set; }

    protected bool canMove = true;
    protected float moveSpeedModifier = 1.0f;
    protected string exitReason;

    virtual public void Setup(StateMachine _parent) {
        parent = _parent;
    }

    public void SetCore(Character _core) {
        core = _core;
    }

    virtual public void Enter() {

    }

    virtual public void Continue() {

    }

    virtual public void FixedContinue() {

    }

    virtual public void Exit(string reason) {
        exitReason = reason;
    }

    virtual public bool ShouldEnter() {
        return true;
    }

    virtual public bool ShouldExit() {
        return true;
    }

    virtual public void PlayNextFrame() {
        core.spriteRenderer.sprite = spriteSheet.sprites[spriteIndex];
        framesSinceSpriteUpdate = 0;
    }

    virtual public void CycleSpriteIndex() {
        if (spriteIndex < spriteSheet.sprites.Length - 1) spriteIndex++;
        else spriteIndex = 0;
    }

    virtual public void NextSpriteIndex() {
        if (spriteIndex < spriteSheet.sprites.Length - 1) spriteIndex++;
        else finished = true;
    }

    virtual public void SubmitActionRequest() {

    }

    virtual public void TryAttack() {

    }
}

