using UnityEngine;
public class OneShin : MonoBehaviour, IAbno
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public int[] playerStats;
    public int dmgType = 1;
    public int dmgAmnt = 2;
    public bool canEscape = false;
    public bool hasAngerMeter = false;
    public int maxAngerCount = 0;
    public int angerCount = 0;
    public int threatLevel = 0;
    public float chanceToGetGift = 0.05f;
    public float egoGiftID;

    // Update is called once per frame
    public void Start() {
        player = GameObject.Find("Bongbong");
    }

    public void onBadWorkResult() {

    }

    public void onNormalWorkResult() {

    }

    public void onGoodWorkResult() {

    }

    public void onEmployeeDeath() {

    }

    public void getEgoGift() {

    }

    





    public GameObject Player 
    { 
        get => player; 
        set => player = value;
    }

    public int[] PlayerStats
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

}
