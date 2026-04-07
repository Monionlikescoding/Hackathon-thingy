using UnityEngine;
using UnityEngine.UIElements;

public class Abnobuttonscripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // (OnEnable is just start but slightly different)
    private void OnEnable()
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
    }

    private void OnButtonClick()
    {
        Debug.Log("[On Click] : Murder");
    }
}
