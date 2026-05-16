using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float dmgType;
    public float dmgAmnt;
    public float atkCD;
    public float cd = 0;
    public float atkDelay;
    public string animTrigName;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        cd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cd += Time.deltaTime;
    }

    public void attack() {
        if(cd >= atkCD) {
            anim.SetTrigger(animTrigName);
            Invoke("ettack", atkDelay);
            cd = 0;
        }
    }
    void ettack() {
        Debug.Log("Attacked");

        BoxCollider2D attackBoxCollider = transform.Find("CloseToAttack").gameObject.GetComponent<BoxCollider2D>();

        Collider2D[] hitColliders = Physics2D.OverlapBoxAll( attackBoxCollider.bounds.center, attackBoxCollider.bounds.size, attackBoxCollider.transform.eulerAngles.z );

        foreach (var hit in hitColliders) {
            if (hit.gameObject.CompareTag("Employee") || hit.gameObject.CompareTag("Player")) {
                Debug.Log(hit.gameObject);
                switch(dmgType) {
                    case 0 : if(hit!=null) {hit.gameObject.GetComponent<IDmgable>().AdjustHp(-dmgAmnt);} break;
                    case 1 : if(hit!=null) {hit.gameObject.GetComponent<IDmgable>().AdjustSp(-dmgAmnt);} break;
                    case 2 : if(hit!=null) {hit.gameObject.GetComponent<IDmgable>().AdjustSp(-dmgAmnt);}if(hit!=null) {hit.gameObject.GetComponent<IDmgable>().AdjustHp(-dmgAmnt);} break;
                }
            }
        }

    }
}
