using UnityEngine;

public class LamentMournDespairEscapedScript : MonoBehaviour, IDmgable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float health = 100;
    public float maxHealth = 100;
    public float dmg = 3;
    public GameObject parentAbno;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0) {
            Die();
        }
    }

    public float Health {get => health; set=> health = value;}
    public float MaxHP {get => maxHealth; set=> maxHealth = value;}
    public float Sp {get => health; set=> health = value;}
    public float MaxSp {get => maxHealth; set=> maxHealth = value;}
    public float Soul {get => health; set=> health = value;}
    public float MaxSoul {get => maxHealth; set=> maxHealth = value;}

    public void AdjustSp(float a){
        health += a*1.2f;
    }
    public void AdjustHp(float a) {
        health += a*1f;
    }
    public void AdjustSoul(float a) {
        health += a*2f;
    }
    public void Die() {
        parentAbno.GetComponent<LamentMournDespair>().onEscapeDeath();
        Destroy(gameObject);
    }
}
