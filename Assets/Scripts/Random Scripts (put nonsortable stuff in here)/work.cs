using UnityEngine;
using System.Collections; 

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
            Debug.Log("Working");
        }
        else if(workingTime<=0){
            playerScript.currentlyWorking = false;
            abno=null;
        }

        workingTime -= 1 * Time.deltaTime;
    }
    public void Work(GameObject Abno, float abnoWorkTime, int amountOfWorks){ // abno, and abno set worktime
        
        //script for working on an abnormality
        abno = Abno;
        float trueTime = (float) (abnoWorkTime * (1 - (playerScript.soulMAX * 0.01)));
        if(trueTime < 0.3) {
            trueTime = 0.3f;
        }
        float totalTime = amountOfWorks * trueTime;
        workingTime = totalTime;
        Debug.Log("plus one little enkephalin");

    }

    public void startWorking() {
        //StartCoroutine
    }

    IEnumerator working(float timeWait, float worksLeft)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(2f); 
        Debug.Log("2 seconds have passed!");
        
        // Wait for 1 frame
        yield return null; 
        Debug.Log("One frame has passed!");
    }
}
