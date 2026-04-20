using UnityEngine;

public interface IAbno {

    GameObject Player{ get; set; } 
    int[] PlayerStats{ get; set; } 
    int DmgType{ get; set; } 
    int DmgAmnt{ get; set; } 
    bool CanEscape{ get; set; } 
    bool HasAngerMeter{ get; set; } 
    int MaxAngerCount{ get; set; } 
    int AngerCount{ get; set; } 
    int ThreatLevel{ get; set; } 
    float ChanceToGetGift{ get; set; } 



    public void onBadWorkResult();

    public void onNormalWorkResult();

    public void onGoodWorkResult();

    public void onEmployeeDeath();

    public void getEgoGift();
}
