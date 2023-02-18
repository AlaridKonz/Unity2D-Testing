using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : StateMachine {
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Rigidbody2D body;
    protected State[] childStates;
    protected Vector2 pos => transform.position;


    private void Awake() {
        childStates = GetComponentsInChildren<State>();
        foreach (State state in childStates) {
            state.SetCore(this);
        }

    }






}
