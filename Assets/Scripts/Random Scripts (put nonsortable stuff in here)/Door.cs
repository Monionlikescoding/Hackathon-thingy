using UnityEngine;
using System.Collections;


public class Door : MonoBehaviour
{
    Animator anim;
    public GameObject exit;
    public int size;
    Transform AnimationRunner;
    Transform GoThroughRunner;
    public bool fullyOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        AnimationRunner = transform.Find("AnimationRunner");
        GoThroughRunner = transform.Find("GoThroughRunner");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {    
        Debug.Log("Triggered");
        // Use tags to identify what entered the zone
        if (other.CompareTag("Player"))
        {

            if (other.IsTouching(GoThroughRunner.GetComponent<Collider2D>()))
            {
                Debug.Log("go through");
                Transform exitPoint = exit.transform.Find("Exit");
                other.gameObject.transform.position = exitPoint.position;
                openDoor();
                exit.GetComponent<Door>().openDoor();
            }
            else if (other.IsTouching(AnimationRunner.GetComponent<Collider2D>()))
            {
                Debug.Log("play animation");
                openDoor();
                exit.GetComponent<Door>().openDoor();
            }
        }
    }
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player"))
        {
            closeDoor();
            exit.GetComponent<Door>().closeDoor();
        }
	}

    public void openDoor() {
        switch(size) {
            case 0: anim.SetBool("open",true); break;
            case 1: anim.SetBool("openSMALL", true); break;
        }
    }
    public void closeDoor() {
        switch(size) {
            case 0: anim.SetBool("open",false); break;
            case 1: anim.SetBool("openSMALL", false); break;
        }
    }

    /*
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
        if (other.CompareTag("Player"))
        {
            anim.SetBool("open",true);
            exit.GetComponent<Door>().anim.SetBool("open",true);
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
    */
    public void OnDoorOpened()
    {
        fullyOpen = true;
    }

    public void OnDoorClosed()
    {
        fullyOpen = false;
    }
}
