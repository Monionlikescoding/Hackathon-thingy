using UnityEngine;
using System.Collections;

public class TrackPlayer : MonoBehaviour
{
    public int Roomid;
    public GameObject[] roomIds;
    public GameObject[] players;
    public GameObject[] employees;
    public ArrayList doors;
    public GameManager gameObjectScript;
    private GameObject currRoom;
    private GameObject target;
    //private char dir;
    private float targetValue; // Basically, how valuable is the target, is it 0 : a door, 0.45 : person already chosen, 0.5 : a door leading to a player/employee, 1 : an employee, 1.5 : a close employee (within the hit boundary (always prioritizes player)), 2 : a player, 3 : a player inside the hit detection collider (not added yet)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1;
    public float currSpeed = 1;
    void Start()
    {
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] employees = GameObject.FindGameObjectsWithTag("Employee");
        doors = new ArrayList();
        target = null;
        currRoom = gameObjectScript.rooms[Roomid];
        
            foreach (Transform child in currRoom.transform)
            {
                bool found = false;
                if(child.gameObject.tag == "Door") {
                    foreach (GameObject P in players) {
                        if(child.gameObject.GetComponent<IDoor>().Exit.GetComponent<IDoor>().RoomID == P.GetComponent<Move>().RoomId){
                            //dir='l';
                            found = true;
                            target = child.gameObject;
                            break;
                        }
                    }

                    foreach (GameObject P in employees) {
                        if(child.gameObject.GetComponent<IDoor>().Exit.GetComponent<IDoor>().RoomID == P.GetComponent<EmployeeMove>().RoomId){
                            //dir='l';
                            found = true;
                            target = child.gameObject;
                            break;
                        }
                    }
			    }
                if(found) {
                    break;
                }
            }
        //ill finish this later or whatever

        
        //Debug.Log(players.Length);
        
        for(int i = 0; i < players.Length; i++) {
            if(players[i].GetComponent<Move>().RoomId == Roomid) {
                target=players[i];
                break;
            }
        }
        if(target == null) {
            for(int i = 0; i < employees.Length; i++) {
                if(employees[i].GetComponent<EmployeeMove>().RoomId == Roomid) {
                    target=employees[i];
                    break;
                }
            }
        }

        if(target != null) {
            bool targetAlrInside = CheckForTarget(target);
            
            Vector2 direction = (target.transform.position - gameObject.transform.position).normalized;
            direction.y = 0;
            if(!targetAlrInside) {
                transform.Translate(direction*Time.deltaTime*currSpeed);
                currSpeed = speed;

            }
            else {
                if(GetComponent<Attack>() != null) {
                    GetComponent<Attack>().attack();
                }
                currSpeed = speed / 3.0f;
            }
            if(direction.x < 0) {
                transform.localScale = new Vector2(-1, 1);
            }
            else if(direction.x > 0) {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    bool CheckForTarget(GameObject target) {
        BoxCollider2D attackBoxCollider = transform.Find("CloseToAttack").gameObject.GetComponent<BoxCollider2D>();

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll( attackBoxCollider.bounds.center, attackBoxCollider.bounds.size, attackBoxCollider.transform.eulerAngles.z );

        foreach (var hit in hitColliders) {
            if (hit.gameObject == target &&  (target.CompareTag("Player") || target.CompareTag("Employee")) ) {
                return true;
            }
        }

        return false;
    }
    public void resetDir(){
        //dir='n';
    }
}
