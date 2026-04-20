using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class workRange : MonoBehaviour
{
    private Workbuttonscripts sc;
    private VisualTreeAsset ind;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sc=transform.parent.GetComponent<Workbuttonscripts>();
        ind=transform.parent.GetComponent<UIDocument>().visualTreeAsset;
        transform.parent.GetComponent<UIDocument>().visualTreeAsset=null;
    }

    // Update is called once per frame
    void Update()
    {

    }
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.CompareTag("Player")){
            transform.parent.GetComponent<UIDocument>().visualTreeAsset=ind;
		}
	}
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            transform.parent.GetComponent<UIDocument>().visualTreeAsset=null;
            sc.workObject.SetActive(false);
        }
    }
}
