using UnityEngine;
using UnityEngine.UIElements;

public class WorkTypeScripts : MonoBehaviour
{
    private GameObject player;
    public int workTime;
    private work wok;
    private GameObject viewPoint;
    public Workbuttonscripts buttonScript;


    private void Start()
    {
        // 1. Get the root VisualElement from the UIDocument component
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; // Gets the root element

        // 2. Find the button by name
        Button myBodyButton = root.Q<Button>("Body"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (myBodyButton != null)
        {
            myBodyButton.clicked += OnBodyButtonClick;
        }

        Button myMindButton = root.Q<Button>("Mind"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (myMindButton != null)
        {
            myMindButton.clicked += OnMindButtonClick;
        }

        Button mySoulButton = root.Q<Button>("Soul"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (mySoulButton != null)
        {
            mySoulButton.clicked += OnSoulButtonClick;
        }

        Button mySpecialButton = root.Q<Button>("Special"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (mySpecialButton != null)
        {
            mySpecialButton.clicked += OnSpecialButtonClick;
        }

        gameObject.SetActive(false);
        player=GameObject.Find("Bongbong");
        viewPoint=GameObject.Find("Main Camera");
        //wok=GameObject.Find("Bongbong").GetComponent<work>();
    }
	private void Update() {
        //if(*whatever code that needs to be here*) gameObject.SetActive(true);
        //else gameObject.SetActive(false);
		gameObject.GetComponent<RectTransform>().transform.position=viewPoint.transform.position+new Vector3(-7.5f,-4f,10);
	}

	private void OnBodyButtonClick()
    {   
        Debug.Log("[On Hit] : Murder");
        buttonScript.start("body");
    }
    private void OnMindButtonClick()
    {   
        Debug.Log("[On Think] : Murder");
        buttonScript.start("mind");
    }
    private void OnSoulButtonClick()
    {   
        Debug.Log("[On Ego] : Murder");
        buttonScript.start("soul");
    }
    private void OnSpecialButtonClick()
    {   
        Debug.Log("[On Special Work] : Murder");
        buttonScript.start("special");
    }
    
}
