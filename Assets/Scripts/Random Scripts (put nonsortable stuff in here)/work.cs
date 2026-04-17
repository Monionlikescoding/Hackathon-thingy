using UnityEngine;

public class work : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject abno;
    private int workingTime = 0;
    public bool isWorking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(workingTime>0){
            //blah blah abno work
        }
        else if(workingTime<=0){
            abno=null;
        }
    }
    public void Work(GameObject evil, int time){
        
        //script for working on an abnormality
    }
}
