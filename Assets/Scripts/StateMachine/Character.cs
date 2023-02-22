using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : StateMachine {
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Rigidbody2D body;
    protected State[] childStates;
    protected Vector2 pos => transform.position;
    public float horizontalMovement;
    public bool jumped;
    public float movementSpeed = 7f;
    public float jumpForce = 14f;


    private void Awake() {
        childStates = GetComponentsInChildren<State>();
        foreach (State state in childStates) {
            state.SetCore(this);
        }

    }






}
