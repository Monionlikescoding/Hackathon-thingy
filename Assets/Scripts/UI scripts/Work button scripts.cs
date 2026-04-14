using UnityEngine;
using UnityEngine.UIElements;

public class Workbuttonscripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    private GameObject player;
    public GameObject cell;
    public int workTime;
    //public VisualTreeAsset inf;
    public UIDocument workUI;
    private work wok;


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
    }

    private void OnButtonClick()
    {   
        Vector2 pos = cell.transform.position;
        pos.y -= 1.3f;
        pos.x += 0.75f;
        player.transform.position = pos;
        wok.Work(cell.transform.Find("Abnormality").gameObject, workTime);
        
        //change work time based on another stat later
    }
}
