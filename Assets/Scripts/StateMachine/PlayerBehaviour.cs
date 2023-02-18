using UnityEngine;

public class PlayerBehaviour : Character {

    [SerializeField] Grounded groundedState;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        state = groundedState;
    }

    void Update() {
        if (!state.finished)
            state.Continue();
    }

    void FixedUpdate() {
        if (!state.finished)
            state.FixedContinue();
    }
}