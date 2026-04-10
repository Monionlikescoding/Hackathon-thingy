using Unity.VisualScripting;
using UnityEngine;

public class Doorteleport : MonoBehaviour
{
    public GameObject exit;
    public int direction; //-1 if door leads left 1 if door leads right this is only because left side doors use a negative offset to move right for some reason??? if you fix that then remove direction
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.transform.position=new Vector3(exit.GetComponent<BoxCollider2D>().offset.x*(-direction)+exit.transform.position.x,exit.GetComponent<BoxCollider2D>().offset.y+exit.transform.position.y-0.2f,collision.transform.position.z);
        }
	}
}
