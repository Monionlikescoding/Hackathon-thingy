using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EmployeeMove : MonoBehaviour, IDmgable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed; // Speed is multiplied by 100
    public float accel;
    public int RoomId;
    public Rigidbody2D playerRb;
    SpriteRenderer spriteRenderer;
    public GameObject currRoom;
    Animator anim;
    public GameManager gameObjectScript;

    public float body = 10f;
    public float bodyMAX = 15f;

    public float mind = 15f;
    public float mindMAX = 15f;

    public float soul=15f;
    public float soulMAX=15f;

    public int employeeState; //1=idle(standing still),2=Moving(moving to adjacent room(s)),3=Working(if you want them to),
                              //4=Healing,5=Combat
    public int stateTimer;
    private List<int> wands;
    private int timer2;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
        

        // Sets speed to default value
        if(speed == 0) {
            speed = 6;
        }
        employeeState=0;
        stateTimer=0;
        playerRb.linearDamping = 20f;
    }

	private void Update() {

        currRoom = gameObjectScript.rooms[RoomId];

        if(soul > soulMAX) {
            soul = soulMAX;
        }
        if(mind > mindMAX) {
            mind = mindMAX;
        }
        if(body > bodyMAX) {
            body = bodyMAX;
        }
        if(body <= 0 || mind <= 0) {
            Die();
        }
	}
	// Fixed update is constant time, (this is needed for applying forces & velocity management as many devices run on different framerates)
	void FixedUpdate()
    {
        //Vector2 moveValue = new Vector2(1,0);
        //playerRb.AddForce(moveValue * speed * 500 * Time.deltaTime);
        //I will finish this dont touchy
        /*
        if(employeeState==1) {
            if(stateTimer==0){
                wands.Insert(0,UnityEngine.Random.Range(60,120));
                timer2=UnityEngine.Random.Range(180,600);
                for(int i=1;i>0;i++){
                    wands.Insert(i,0);
                    if(wands[i]>=timer2) break;
                }
            }
        }
        */

        //stateTimer++;
		Vector2 vel = playerRb.linearVelocity;


        vel.x = Mathf.Clamp(vel.x, -speed, speed); // clamping x-velocity to speed
        playerRb.linearVelocity = vel;
    }

    public float Health {get => body; set=> body = value;}
    public float MaxHP {get => bodyMAX; set=> bodyMAX = value;}
    public float Sp {get => mind; set=> mind = value;}
    public float MaxSp {get => mindMAX; set=> mindMAX = value;}
    public float Soul {get => soul; set=> soul = value;}
    public float MaxSoul {get => soulMAX; set=> soulMAX = value;}

    public void AdjustSp(float a){
        mind += a;
    }
    public void AdjustHp(float a) {
        body += a;
    }
    public void AdjustSoul(float a) {
        soul += a;
    }
    public void Die() {
        Destroy(gameObject);
    }


}
