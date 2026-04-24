using UnityEngine;
using System.Collections; 

public class work : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject abno;
    private GameObject doorToTpTo;
    private string workType;
    private Coroutine thing;
    private float workingTime = 0;
    private int amntToDo;
    private float amntToWait;
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

        //workingTime -= 1 * Time.deltaTime;
    }
    public void Work(GameObject Abno, float abnoWorkTime, int amountOfWorks, GameObject door, string WorkType){ // abno, and abno set worktime
        
        //script for working on an abnormality
        abno = Abno;
        float trueTime = (float) (abnoWorkTime * (1 - (playerScript.soulMAX * 0.01)));
        if(trueTime < 0.3) {
            trueTime = 0.3f;
        }
        float totalTime = amountOfWorks * trueTime;
        workingTime = totalTime;
        amntToWait = trueTime;
        amntToDo = amountOfWorks;
        workType = WorkType;
        InvokeRepeating("startWorking", amntToWait, amntToWait);
        Debug.Log("plus one little enkephalin");
        doorToTpTo = door;

    }

    public void startWorking() {
        working();
    }

    public void working()
    {      
        float chancetoget = abno.GetComponent<IAbno>().ChanceToGetEnk;
        float rollValue = Random.Range(0.0f, 1.0f); 
        switch(workType) {
            case "Body" : if(rollValue < (chancetoget + playerScript.bodyMAX*0.005)) {Debug.Log("plus one little enkephalin");} else {Debug.Log("not plus one little enkephalin");} break;
            case "Mind" : if(rollValue < (chancetoget + playerScript.mindMAX*0.005)) {Debug.Log("plus one little enkephalin");} else {Debug.Log("not plus one little enkephalin");} break;
            case "Soul" : if(rollValue < (chancetoget + playerScript.soulMAX*0.005)) {Debug.Log("plus one little enkephalin");} else {Debug.Log("not plus one little enkephalin");} break;
            case "Special" : Debug.Log("plus one little enkephalin"); break;
        }
        Debug.Log("plus one little enkephalin");
        workingTime -= amntToWait;
        amntToDo--;
        if(workingTime < 0) {
            Vector2 tpPos = doorToTpTo.transform.position;
            tpPos.y -= 0.5f;
            gameObject.transform.position = tpPos;
            playerScript.RoomId = doorToTpTo.GetComponent<CorridorDoor>().corridorRoomId;

            CancelInvoke("startWorking");
        }
    }
}
