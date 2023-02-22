using UnityEngine;

public class State : StateMachine {
    protected Character core;
    protected StateMachine parent;
    // protected State substate;

    [SerializeField] protected int framerate = 10;
    protected SpriteSheet spriteSheet;
    protected int spriteIndex = 0;
    protected int frameCounter = 0;
    protected int framesSinceSpriteUpdate = 0;
    protected float startTime;
    protected float time => Time.time - startTime;
    protected bool hasNotReachedFrameRateTime => framesSinceSpriteUpdate++ < framerate;
    public bool finished { get; protected set; }
    protected float frameUpdateTime => 1.0f / (float)framerate;
    protected float timeSinceLastUpdate = 0;
    protected bool isTimeToUpdate => timeSinceLastUpdate >= frameUpdateTime;

    protected bool canMove = true;
    protected bool canAttack = true;
    protected bool stayPassive = false;
    protected bool canJump = true;
    protected float moveSpeedModifier = 1.0f;
    protected string exitReason;

    virtual protected void Awake() {
        spriteSheet = GetComponent<SpriteSheet>();
        Enter();
    }

    virtual public void Setup(StateMachine _parent) {
        parent = _parent;
    }

    public void SetCore(Character _core) {
        core = _core;
    }

    virtual public void Enter() {
        finished = false;
        startTime = Time.time;
        frameCounter = 0;
        spriteIndex = 0;
        framesSinceSpriteUpdate = 0;
        timeSinceLastUpdate = 0;
        trigger = null;
        moveSpeedModifier = 1.0f;
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
        if (substate != null) substate.TryAttack();
    }

    virtual public void TryMovement(float horizontalMovement) {
        TurnTowards(horizontalMovement);
        if (!canMove) return;
        if (substate != null) substate.TryMovement(horizontalMovement);
    }

    virtual public void TryJump() {
        if (substate != null) substate.TryJump();
    }

    virtual public void TryBlock() {
        if (substate != null) substate.TryBlock();
    }

    virtual public void TryDodge() {
        if (substate != null) substate.TryDodge();
    }

    public State getDeepState() {
        if (substate != null) return substate.getDeepState();
        else return this;
    }

    private void TurnTowards(float horizontalMovement) {
        if (horizontalMovement != 0)
            core.transform.localScale = new Vector3(Mathf.Sign(horizontalMovement), 1, 1);
    }
}

