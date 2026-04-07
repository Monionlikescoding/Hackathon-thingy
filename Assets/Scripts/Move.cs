using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float accel;
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
        Vector2 moveValue = moveAction.ReadValue<Vector2>()*speed/accel;
        moveValue.y=0; // you can only move in the x-direction

        playerRb.AddForce(moveValue * speed * Time.deltaTime);

        Vector2 vel = playerRb.linearVelocity;

        if(moveValue.y==0){ //if the player doesn't hold a direction key, automatic deceleration happens
            if(vel.x>0){
                vel.x-=speed/400;
            }
            else if(vel.x<0){
                vel.x+=speed/400;
            }
            if(Math.Abs(vel.x)<speed/400){
                vel.x=0;
            }
        }

        vel.x = Mathf.Clamp(vel.x, -speed/100, speed/100); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;

        if(moveValue.x < 0) {
            spriteRenderer.flipX = true;
        }
        else if(moveValue.x > 0) {
            spriteRenderer.flipX = false;
        }
    }
}
