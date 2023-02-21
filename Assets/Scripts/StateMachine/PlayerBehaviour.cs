using UnityEngine;

public class PlayerBehaviour : Character {

    [SerializeField] Grounded groundedState;
    public InputManager inputManager { get; private set; }

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        substate = groundedState;
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    void Update() {
        horizontalMovement = inputManager.GetMovement();
        jumped = inputManager.PressedJump();
        bool attacked = inputManager.PressedAttack();
        if (attacked) substate.TryAttack();

        if (!substate.finished)
            substate.Continue();

    }

    void FixedUpdate() {
        if (!substate.finished)
            substate.FixedContinue();
    }
}