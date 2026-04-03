using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    InputAction moveAction;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        moveValue.y=0; // you can only move in the x-direction

        playerRb.AddForce(moveValue * speed);

        Vector2 vel = playerRb.linearVelocity;
        vel.x = Mathf.Clamp(vel.x, -speed/12, speed/12); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;

        if(moveValue.x < 0) {
            spriteRenderer.flipX = true;
        }
        else if(moveValue.x > 0) {
            spriteRenderer.flipX = false;
        }
    }
}
