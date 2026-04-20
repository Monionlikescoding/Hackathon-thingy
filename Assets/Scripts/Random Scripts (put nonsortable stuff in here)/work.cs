using UnityEngine;

public class work : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject abno;
    private float workingTime = 0;
    public bool isWorking = false;
    public Move playerScript;
    void Start()
    {
        playerScript = GetComponentInParent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(workingTime>0){
            playerScript.currentlyWorking = true;
        }
        else if(workingTime<=0){
            playerScript.currentlyWorking = false;
            abno=null;
        }

        workingTime -= 1 * Time.deltaTime;
    }
    public void Work(GameObject evil, int time){
        
        //script for working on an abnormality
    }
}
