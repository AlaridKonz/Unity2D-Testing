using UnityEngine;

public class PlayerBehaviour : Character {

    [SerializeField] RootPlayerState rootPlayerState;
    public InputManager inputManager { get; private set; }
    public State currentState;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        Set(rootPlayerState, false, "initial state");
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    void Update() {
        currentState = substate.getDeepState();
        horizontalMovement = inputManager.GetMovement();
        jumped = inputManager.PressedJump();
        bool blocked = inputManager.PressedBlock();
        bool attacked = inputManager.PressedAttack();
        if (attacked) substate.TryAttack();
        if (blocked) {
            if (horizontalMovement == 0) substate.TryBlock();
            else substate.TryDodge();
        }

        if (!substate.finished)
            substate.Continue();

    }

    void FixedUpdate() {
        if (jumped) substate.TryJump();
        else substate.TryMovement(horizontalMovement);
        jumped = false;
        if (!substate.finished)
            substate.FixedContinue();
    }
}