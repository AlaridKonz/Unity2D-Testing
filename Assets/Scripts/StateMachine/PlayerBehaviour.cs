using UnityEngine;

public class PlayerBehaviour : Character {

    [SerializeField] RootPlayerState rootPlayerState;
    public InputManager inputManager { get; private set; }
    public State currentState;
    // [SerializeField] private float actionBufferTime = 0.2f;

    void Start() {
        Set(rootPlayerState, false, "initial state");
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }

    void Update() {
        currentState = substate.getDeepState();
        horizontalInput = inputManager.GetMovement();
        verticalInput = inputManager.GetVertical();
        jumped = jumped || inputManager.PressedJump();
        bool blocked = inputManager.PressedBlock();
        bool attacked = inputManager.PressedAttack();
        if (attacked) substate.TryAttack();
        if (blocked) {
            if (horizontalInput == 0) substate.TryBlock();
            else substate.TryDodge();
        }

        if (!substate.finished)
            substate.Continue();

    }

    void FixedUpdate() {
        if (jumped) substate.TryJump();
        else substate.TryMovement(horizontalInput, verticalInput);
        jumped = false;
        if (!substate.finished)
            substate.FixedContinue();
    }
}