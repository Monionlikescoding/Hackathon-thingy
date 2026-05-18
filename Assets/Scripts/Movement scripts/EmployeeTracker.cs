using UnityEngine;
using System.Collections;

public class EmployeeTracker : MonoBehaviour
{
    public int Roomid;
    public GameObject[] roomIds;
    public GameObject[] Abnos;
    public ArrayList doors;
    public GameManager gameObjectScript;
    private GameObject currRoom;
    private GameObject target;
    //private char dir;
    private float targetValue; // Basically, how valuable is the target, is it 0 : a door, 0.45 : person already chosen, 0.5 : a door leading to a player/employee, 1 : an employee, 1.5 : a close employee (within the hit boundary (always prioritizes player)), 2 : a player, 3 : a player inside the hit detection collider (not added yet)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1;
    public float atkCDMAX = 0.6f;
    public float atkCD = 0f;
    public float dmg = 3f;
    public float dmgType = 0f;
    public float timer;
    public Vector2 pos;
    public bool wantsToGoThroughElevator;
    Animator anim;
    void Start()
    {
        gameObjectScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GameObject[] Abnos = GameObject.FindGameObjectsWithTag("EscapedAbno");
        anim = GetComponent<Animator>();
        pos = createNewPos();
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject[] Abnos = GameObject.FindGameObjectsWithTag("EscapedAbno");
        doors = new ArrayList();
        target = null;
        currRoom = gameObjectScript.rooms[Roomid];
        atkCD += Time.deltaTime;
        
            foreach (Transform child in currRoom.transform)
            {
                bool found = false;
                if(child.gameObject.tag == "Door") {
                    foreach (GameObject P in Abnos) {
                        if(child.gameObject.GetComponent<IDoor>().Exit.GetComponent<IDoor>().RoomID == P.GetComponent<TrackPlayer>().Roomid){
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
        
        for(int i = 0; i < Abnos.Length; i++) {
            if(Abnos[i].GetComponent<TrackPlayer>().Roomid == Roomid) {
                target=Abnos[i];
                break;
            }
        }

        if(target != null) {
            bool targetAlrInside = CheckForTarget(target);
            
            Vector2 direction = (target.transform.position - gameObject.transform.position).normalized;
            direction.y = 0;
            if(!targetAlrInside) {
                transform.Translate(direction*Time.deltaTime*speed);
            }
            else {
                attack();
                direction.x = 0;
            }

            if(direction.x != 0) {
                anim.SetBool("walking", true);
            }
            else {
                anim.SetBool("walking", false);
            }

            if(direction.x < 0) {
                transform.localScale = new Vector2(-1, 1);
            }
            else if(direction.x > 0) {
                transform.localScale = new Vector2(1, 1);
            }
        }
        else {
            Vector2 direction = pos;
            if(timer <= 0) {
                timer = Random.Range(0f, 4f);
                pos = createNewPos();
                wantsToGoThroughElevator = true;
            }
            direction.y = 0;
            transform.Translate(direction*Time.deltaTime*speed);

            if(direction.x != 0) {
                anim.SetBool("walking", true);
            }
            else {
                anim.SetBool("walking", false);
            }

            if(direction.x < 0) {
                transform.localScale = new Vector2(-1, 1);
            }
            else if(direction.x > 0) {
                transform.localScale = new Vector2(1, 1);
            }
        }
        timer -= Time.deltaTime;
    }

    bool CheckForTarget(GameObject target) {
        BoxCollider2D attackBoxCollider = transform.Find("CloseToAttack").gameObject.GetComponent<BoxCollider2D>();

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll( attackBoxCollider.bounds.center, attackBoxCollider.bounds.size, attackBoxCollider.transform.eulerAngles.z );

        foreach (var hit in hitColliders) {
            if (hit.gameObject == target) {
                return true;
            }
        }

        return false;
    }

    public void attack() {
        if(atkCD >= atkCDMAX) {
            anim.SetTrigger("swipe");
			atkCD = 0f;
            Invoke("Attack", 0.45f);
        }
    }

    void Attack() {
        Debug.Log("Attacked");

        BoxCollider2D attackBoxCollider = transform.Find("CloseToAttack").gameObject.GetComponent<BoxCollider2D>();

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll( attackBoxCollider.bounds.center, attackBoxCollider.bounds.size, attackBoxCollider.transform.eulerAngles.z );

        foreach (var hit in hitColliders) {
            if (hit.gameObject.CompareTag("EscapedAbno")) {
                Debug.Log(hit.gameObject);
                switch(dmgType) {
                    case 0 : hit.gameObject.GetComponent<IDmgable>().AdjustHp(-dmg); break;
                    case 1 : hit.gameObject.GetComponent<IDmgable>().AdjustSp(-dmg); break;
                    case 2 : hit.gameObject.GetComponent<IDmgable>().AdjustSoul(-dmg); break;
                }
            }
        }

    }
    Vector2 createNewPos() {
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), 0).normalized;
        return direction;
    }
}
