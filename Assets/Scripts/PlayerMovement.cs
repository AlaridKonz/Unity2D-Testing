using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private MovementState state;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private bool isUpright => state != MovementState.Ducking && state != MovementState.Crawling;
    private bool isFalling => state == MovementState.Jumping && dir_Y < 0;

    [SerializeField] private LayerMask GroundLayer;

    private float dir_X;
    private float dir_Y;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        state = MovementState.Ready;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        dir_X = Input.GetAxisRaw("Horizontal");
        if (dir_X != 0)
            Turn(dir_X);

        if (IsGrounded()) {
            handleGroundMovement();
        }
        else {
            handleJump();
        }


        animator.SetInteger("PlayerState", (int)state);
    }

    private void handleGroundMovement() {
        if (Input.GetButton("Down")) {
            state = MovementState.Ducking;
        }
        else if (Input.GetButtonUp("Down")) {
            state = MovementState.Ready;
        }
        if (dir_X == 0) { // Standing still
            state = isUpright ? MovementState.Ready : MovementState.Ducking;
        }
        else { // Moving
            state = isUpright ? MovementState.Running : MovementState.Crawling;
        }

        if (state == MovementState.Jumping || state == MovementState.Falling) {
            // Trigger Landing
        }
        if (Input.GetButtonDown("Jump")) {
            dir_Y = 1;
            // Trigger takeoff
            state = MovementState.Jumping;
        }

    }

    private void handleJump() {
        if (isFalling) {
            state = MovementState.Falling;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dir_X * moveSpeed, rb.velocity.y);
        if (dir_Y == 1) {
            rb.velocity = new Vector2(rb.velocity.x, dir_Y * jumpForce);
            dir_Y = 0;
        }
    }

    private bool IsGrounded() {
        return Physics2D.BoxCast(bc.bounds.center, bc.size, 0f, Vector2.down, 0.1f, GroundLayer);

    }

    private void Turn(float direction) {
        transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
    }
}
