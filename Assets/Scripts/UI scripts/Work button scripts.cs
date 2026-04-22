using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Workbuttonscripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    private GameObject player;
    public GameObject cell;
    public GameObject abno;
    public GameObject workObject;
    public float workTime;
    //public VisualTreeAsset inf;
    public UIDocument workUI;
    private work wok;
    public int roomID;


    private void Start()
    {
        // 1. Get the root VisualElement from the UIDocument component
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; // Gets the root element

        // 2. Find the button by name
        Button myButton = root.Q<Button>("ClicktoWork"); // Gets the button

        // 3. Assign the function to the 'clicked' event
        if (myButton != null)
        {
            myButton.clicked += OnButtonClick;
        }

        player=GameObject.Find("Bongbong");
        wok=GameObject.Find("Bongbong").GetComponent<work>();
        workObject=GameObject.Find("WorkUI");
    }

	private void Update() {
	}

	private void OnButtonClick()
    {   
        IAbno abnoIF = abno.GetComponent<IAbno>();
        workTime = abnoIF.WorkTime;
        workObject.SetActive(true);
        workObject.GetComponent<WorkTypeScripts>().FixingButtons();
        workObject.GetComponent<WorkTypeScripts>().buttonScript=this;
        Debug.Log("clicked");
        //change work time based on another stat later
    }
    public void start(string workType){
        workObject.SetActive(false);
        Vector2 pos = cell.transform.position;
        pos.y -= 1.3f;
        pos.x += 0.75f;
        player.transform.position = pos;
        player.GetComponent<Move>().RoomId = roomID;
        GameObject AbNo = cell.transform.Find("Abnormality").gameObject;
        wok.Work(AbNo, workTime, AbNo.GetComponent<IAbno>().AmountOfWorks);
        Debug.Log("Something happened");
    }
}
