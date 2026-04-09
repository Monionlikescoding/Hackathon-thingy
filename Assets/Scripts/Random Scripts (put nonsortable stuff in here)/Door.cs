using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
    public int size;
    public int ID;
    public Transform exitPoint;
    private bool fullyOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Use tags to identify what entered the zone
        if (other.CompareTag("Player"))
        {   
            switch(size) {
                case 0: anim.SetBool("open",true); break;
                case 1: anim.SetBool("openSMALL", true); break;
            }
        }
        
    }

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player"))
        {
            switch(size) {
                case 0: anim.SetBool("open",false); break;
                case 1: anim.SetBool("openSMALL", false); break;
            }
        }
	}

    public void UseDoor(GameObject player) {
        if (exitPoint != null && fullyOpen)
        {   
            player.transform.position = exitPoint.position;
        }
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
