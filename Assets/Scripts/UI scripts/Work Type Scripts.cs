using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorkTypeScripts : MonoBehaviour
{
    private GameObject player;
    public int workTime;
    private work wok;
    private GameObject viewPoint;
    public Workbuttonscripts buttonScript;
    public bool Using = false;
    public Button body;
    public Button mind;
    public Button soul;
    public Button special;


    private void Start()
    {
        //wok=GameObject.Find("Bongbong").GetComponent<work>();
        body=transform.Find("HealthButton").GetComponent<Button>();
        body.onClick.AddListener(OnBodyButtonClick);
		mind=transform.Find("MindButton").GetComponent<Button>();
        mind.onClick.AddListener(OnMindButtonClick);
		soul=transform.Find("SoulButton").GetComponent<Button>();
        soul.onClick.AddListener(OnSoulButtonClick);
		special=transform.Find("SpecialButton").GetComponent<Button>();
        special.onClick.AddListener(OnSpecialButtonClick);
        gameObject.SetActive(false);
	}
	private void Update() {
        //if(*whatever code that needs to be here*) gameObject.SetActive(true);
        //else gameObject.SetActive(false);
	}

	private void OnBodyButtonClick()
    {   
        Debug.Log("[On Hit] : Murder");
        buttonScript.start("Body");
	}
    private void OnMindButtonClick()
    {   
        Debug.Log("[On Think] : Murder");
        buttonScript.start("Mind");
	}
    private void OnSoulButtonClick()
    {   
        Debug.Log("[On Ego] : Murder");
        buttonScript.start("Soul");
	}
    private void OnSpecialButtonClick()
    {   
        Debug.Log("[On Special Work] : Murder");
        buttonScript.start("Special");
	}
    
}
