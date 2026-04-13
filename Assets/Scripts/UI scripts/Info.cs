using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class Info : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    void Start()
    {
        player=GameObject.Find("Bongbong");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position=player.transform.position;
    }
    public void showInfo(VisualTreeAsset info){
        gameObject.GetComponent<UIDocument>().visualTreeAsset=info;
    }
    public void hideInfo(){
        gameObject.GetComponent<UIDocument>().visualTreeAsset=null;
    }
}
