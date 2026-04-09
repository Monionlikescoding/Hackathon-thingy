using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; // Speed is multiplied by 100
    public float accel;
    InputAction moveAction;
    public InputAction interact;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    private bool nearDoor = false;
    private GameObject currentDoor;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        interact = InputSystem.actions.FindAction("Interact");
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        // Sets speed to default value
        if(speed == 0) {
            speed = 6;
        }

        playerRb.linearDamping = 20f;
    }

    // Fixed update is constant time, (this is needed for applying forces & velocity management as many devices run on different framerates)
    void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>(); // no need to divide it by accel
        moveValue.y=0; // you can only move in the x-direction

        playerRb.AddForce(moveValue * speed * 500 * Time.deltaTime);

        Vector2 vel = playerRb.linearVelocity;

        // Currently trying to fix accel so it uses linear damping instead of hardcoding it
        // Test the code, uncomment this out if it doesn't work. Also, linear dampening should be at 10 rn, and speed at 6
        /*
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
        */

        vel.x = Mathf.Clamp(vel.x, -speed, speed); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;

        if(moveValue.x != 0) {
            anim.SetBool("walking", true);
        }
        else {
            anim.SetBool("walking", false);
        }

        if(moveValue.x < 0) {
            transform.localScale = new Vector2(-1, 1);
        }
        else if(moveValue.x > 0) {
            transform.localScale = new Vector2(1, 1);
        }

        
    }

    void Update() {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E pressed (direct check)");
        }
    }

    // Door code
    private void OnInteract(InputAction.CallbackContext context)
    {
        if (!nearDoor || currentDoor == null) return;

        currentDoor.GetComponent<Door>().UseDoor(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            nearDoor = true;
            currentDoor = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            nearDoor = false;
            currentDoor = null;
        }
    }

        private void OnEnable()
    {
        interact.Enable();
        interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        interact.performed -= OnInteract;
        interact.Disable();
    }

}
