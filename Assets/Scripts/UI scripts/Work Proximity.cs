using UnityEngine;

public class WorkProximity : MonoBehaviour
{
    private GameObject work;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        work=transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision) {
		work.GetComponent<Workbuttonscripts>().enter(collision);
	}
	private void OnTriggerExit2D(Collider2D collision) {
		work.GetComponent<Workbuttonscripts>().exit(collision);
	}
}
