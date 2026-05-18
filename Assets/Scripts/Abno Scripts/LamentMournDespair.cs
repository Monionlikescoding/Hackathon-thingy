using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class LamentMournDespair : MonoBehaviour, IAbno
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float[] playerStats;
    public int dmgType = 2;
    public int dmgAmnt = 2;
    public bool canEscape = false;
    public bool hasAngerMeter = false;
    public int maxAngerCount = 0;
    public int angerCount = 0;
    public int workType;
    public int threatLevel = 0;
    public float chanceToGetGift = 0.05f;
    public float chanceToGetEnkH = 0.1f;
    public float chanceToGetEnkM = 0.5f;
    public float chanceToGetEnkS = 0.3f;
    public float workTime = 1;
    public int amountOfWorks = 12;
    public int good=8;
    public int bad=4;
    public float egoGiftID;
    public int workResult;
    public float cooldown=5f;
    private float currentCD=-1f;
    public int id = 2;
    public bool[] entities;
    private GameObject cd;
    private GameObject result;
    private variableScript mang; 
    private ArrayList tem;
    public GameObject mourn;
    public GameObject despair;
    public GameObject lament;

    public GameObject mournPB;
    public GameObject despairPB;
    public GameObject lamentPB;

    public bool angry;

    // Update is called once per frame
    public void Start() {
        player = GameObject.Find("Bongbong");
        Move playerScript = player.GetComponent<Move>();
        playerStats = new float[4];
        playerStats[0] = playerScript.bodyMAX; // use max stat
        playerStats[1] = playerScript.mindMAX;
        playerStats[2] = playerScript.soulMAX;
        if(playerScript.Favors[id-1]) {
            playerStats[3] = 1;
        }
        else {
            playerStats[3] = 0;
        }
        currentCD=-1;
        cd=transform.parent.Find("Enk WorldSpace").Find("WorkResultUI").Find("WorkCoolDown").gameObject;
        cd.GetComponent<TextMeshProUGUI>().text = "";
        result=transform.parent.Find("Enk WorldSpace").Find("WorkResultUI").Find("WorkResult").gameObject;
        result.GetComponent<Image>().enabled=false;
        mang=GameObject.Find("Game Manager").GetComponent<variableScript>();

		Transform parentTransform = transform.parent;
        
        if (parentTransform != null)
        {
            Transform worldSpace = parentTransform.Find("Enk WorldSpace");
            if (worldSpace != null)
            {
                Transform textChild = worldSpace.Find("Enk Text");
                
                if (textChild != null)
                {
                    textChild.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }
        entities = new bool[3];
    }
    
	public void FixedUpdate() {
		if(currentCD>0){
            currentCD--;
            cd.GetComponent<TextMeshProUGUI>().text = ((int)currentCD/60).ToString();
            
            switch(workResult) {
                case 0: cd.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255); break; // RGB Alpha
                case 1: cd.GetComponent<TextMeshProUGUI>().color = new Color32(255, 168, 0, 255); break;
                case 2: cd.GetComponent<TextMeshProUGUI>().color = new Color32(0, 255, 0, 255); break;
            }

		}
        if(currentCD==0){
            foreach (GameObject item in tem)
            {
                Destroy(item);
            }
            currentCD--;
            cd.GetComponent<TextMeshProUGUI>().text = "";
            result.GetComponent<Image>().enabled=false;
            transform.parent.Find("Enk WorldSpace").Find("Enk Text").gameObject.GetComponent<TextMeshProUGUI>().enabled=false;
        }
        if(angerCount <= 0 && angry == false) {
            angerCount = maxAngerCount;
            Color c = GetComponentInChildren<SpriteRenderer>().color;
            c.a = 0f;
            GetComponentInChildren<SpriteRenderer>().color = c;
            lament = Instantiate(lamentPB, new Vector2(0,-1.8f), Quaternion.identity);
            lament.GetComponent<LamentMournDespairEscapedScript>().parentAbno = gameObject;
            mourn = Instantiate(mournPB, new Vector2(7,-4), Quaternion.identity);
            mourn.GetComponent<LamentMournDespairEscapedScript>().parentAbno = gameObject;
            despair = Instantiate(despairPB, new Vector2(-7,-4), Quaternion.identity);
            despair.GetComponent<LamentMournDespairEscapedScript>().parentAbno = gameObject;
            amountOfWorks = 1;
            angry = true;
        }
        if(angry) {
            angerCount = maxAngerCount;
        }
	}

    public void finished(int enke){
        currentCD=cooldown*60;
        result.GetComponent<Image>().enabled=true;
        tem=player.GetComponent<work>().temps;
        if(enke<=bad){
            result.GetComponent<Image>().sprite=mang.bad;
            onBadWorkResult();
            workResult = 0;
        }
        else if(enke>=good){
            result.GetComponent<Image>().sprite=mang.good;
            onGoodWorkResult();
            workResult = 2;
        }
        else{
            result.GetComponent<Image>().sprite=mang.norm;
            onNormalWorkResult();
            workResult = 1;
		}
	}

	public void onBadWorkResult() {
        player.GetComponent<Move>().mind = 0;
        angerCount--;
    }

    public void onNormalWorkResult() {
        angerCount--;
    }

    public void onGoodWorkResult() {
        player.GetComponent<Move>().mind = player.GetComponent<Move>().mindMAX;
        angerCount--;
    }

    public void onEmployeeDeath() {
        angerCount-=2;
    }

    public void getEgoGift() {

    }

    public void onEscapeDeath(int a) {
        switch(a) {
            case 0: entities[0] = true; lament = null; break;
            case 1: entities[1] = true; mourn = null; break;
            case 2: entities[2] = true; despair = null; break;
        }
        if((entities[0] && entities[1] && entities[2])) {
            angry = false;
            entities = new bool[3];
            Color c = GetComponentInChildren<SpriteRenderer>().color;
            c.a = 1f;
            GetComponentInChildren<SpriteRenderer>().color = c;
            amountOfWorks = 12;
        }
    }

    





    public GameObject Player 
    { 
        get => player; 
        set => player = value;
    }

    public float[] PlayerStats
    { 
        get => playerStats; 
        set => playerStats = value;
    }
    public int DmgType 
    { 
        get => dmgType; 
        set => dmgType = value;
    }
    public int DmgAmnt 
    { 
        get => dmgAmnt; 
        set => dmgAmnt = value;
    }
    public bool CanEscape 
    { 
        get => canEscape; 
        set => canEscape = value;
    }
    public bool HasAngerMeter 
    { 
        get => hasAngerMeter; 
        set => hasAngerMeter = value;
    }
    public int MaxAngerCount 
    { 
        get => maxAngerCount; 
        set => maxAngerCount = value;
    }
    public int AngerCount 
    { 
        get => angerCount; 
        set => angerCount = value;
    }

    public int ThreatLevel 
    { 
        get => threatLevel; 
        set => threatLevel = value;
    }

    public float ChanceToGetGift 
    { 
        get => chanceToGetGift; 
        set => chanceToGetGift = value;
    }

    public float WorkTime 
    { 
        get => workTime; 
        set => workTime = value;
    }
    
    public int Id 
    { 
        get => id;
        set => id = value;
    }

    public int Good 
    { 
        get => good;
        set => good = value;
    }

    public int Bad 
    { 
        get => bad;
        set => bad = value;
    }

    public int AmountOfWorks 
    { 
        get => amountOfWorks;
        set => amountOfWorks = value;
    }

    public int WorkType 
    { 
        get => workType;
        set => workType = value;
    }

    public float ChanceToGetEnkH 
    { 
        get => chanceToGetEnkH;
        set => chanceToGetEnkH = value;
    }

    public float ChanceToGetEnkM 
    { 
        get => chanceToGetEnkM;
        set => chanceToGetEnkM = value;
    }

    public float ChanceToGetEnkS 
    { 
        get => chanceToGetEnkS;
        set => chanceToGetEnkS = value;
    }

    public float Cooldown 
    { 
        get => cooldown;
        set => cooldown = value;
    }

    public float CurrentCD 
    { 
        get => currentCD;
        set => currentCD = value;
    }

}
