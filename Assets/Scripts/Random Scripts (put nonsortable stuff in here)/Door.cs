using UnityEngine;
using System.Collections;


public class Door : MonoBehaviour
{
    Animator anim;
    public int size;
    public int ID;
    public GameObject exitPoint;
    public Door otherDoorScript;
    public bool fullyOpen = false;
    public int stateOfOpening; // This is when the door is opening because another door opens this door
    public bool calledAlready = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if(exitPoint != null) {
            otherDoorScript = exitPoint.GetComponentInParent<Door>();
        }
        else {
            Debug.Log("No exit point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stateOfOpening == 1) {
            if(fullyOpen) {
                switch(size) {
                    case 0: anim.SetBool("open",false); break;
                    case 1: anim.SetBool("openSMALL", false); break;
                }
                stateOfOpening = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Use tags to identify what entered the zone
        if (other.CompareTag("Player") && stateOfOpening != 1)
        {   
            switch(size) {
                case 0: anim.SetBool("open",true); break;
                case 1: anim.SetBool("openSMALL", true); break;
            }
        }
        
    }

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player") && stateOfOpening != 1)
        {
            switch(size) {
                case 0: anim.SetBool("open",false); break;
                case 1: anim.SetBool("openSMALL", false); break;
            }
        }
	}

    public void openThisDoor() {
        switch(size) {
            case 0: anim.SetBool("open",true); break;
            case 1: anim.SetBool("openSMALL", true); break;
        }
        stateOfOpening = 1;
    }

    public void UseDoor(GameObject player) {
        if (exitPoint != null && fullyOpen && !calledAlready)
        {   
            otherDoorScript.openThisDoor();
            calledAlready = true;
            StartCoroutine(teleportPlayer(0.15f, player)); // first param is seconds, second param is player
        }
    }

    IEnumerator teleportPlayer(float delayTime, GameObject player)
    {
        yield return new WaitForSeconds(delayTime);
        player.transform.position = exitPoint.transform.position;
        calledAlready = false;
    }

    public void OnDoorOpened()
    {
        fullyOpen = true;
    }

    public void OnDoorClosed()
    {
        fullyOpen = false;
    }
}
