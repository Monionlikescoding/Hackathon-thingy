using UnityEngine;

public class Door : MonoBehaviour
{
    Animator anim;
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
            anim.SetBool("open",true);
        }
    }
	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player"))
        {
            anim.SetBool("open",false);
        }
	}
}
