using UnityEngine;
[System.Serializable]
public class OneShinAbnoCode : MonoBehaviour, IAbno
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public int[] playerStats;
    public int dmgType = 1;
    public int dmgAmnt = 2;
    public bool canEscape = false;
    public bool hasAngerMeter = false;
    public int maxAngerCount = 0;
    public int AngerCount = 0;
    public int threatLevel = 0;
    public float chanceToGetGift = 0.05;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
