using UnityEngine;

public interface IAbno {
    GameObject player {get;}
    int[] playerStats {get;}
    int dmgType {get;}
    int dmgAmnt {get;}
    bool canEscape {get;}
    bool hasAngerMeter {get;}
    int maxAngerCount {get;}
    int AngerCount {get;}
    int threatLevel {get;}
    float chanceToGetGift {get;}

    public void onBadWorkResult();

    public void onNormalWorkResult();

    public void onGoodWorkResult();

    public void onEmployeeDeath();

    public void getEgoGift();
}
