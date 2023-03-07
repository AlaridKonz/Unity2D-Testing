using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : StateMachine {
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Rigidbody2D body;
    [HideInInspector] public Collider2D coll;
    private LayerMask ground;
    protected State[] childStates;
    protected Vector2 pos => transform.position;
    public float horizontalInput;
    public float verticalInput;
    public bool jumped;
    public float movementSpeed = 7f;
    public float jumpForce = 14f;
    public float facingDirection => transform.localScale.x;


    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        ground = LayerMask.GetMask("Ground");
        childStates = GetComponentsInChildren<State>();
        foreach (State state in childStates) {
            state.SetCore(this);
        }
    }

    public bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }






}
