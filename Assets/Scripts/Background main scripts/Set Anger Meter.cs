using UnityEngine;
using TMPro;

public class SetAngerMeter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public IAbno Iabno;
    private TextMeshPro scoreText;
    public Sprite XSprite;
    private SpriteRenderer theSprite;
    void Start()
    {
        Iabno = GetComponentInChildren<IAbno>();
        theSprite = transform.Find("Anger Counter").gameObject.GetComponent<SpriteRenderer>();
        scoreText = transform.Find("Anger Counter").GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Iabno.HasAngerMeter) {
            scoreText.text = (Iabno.AngerCount) + "";
            scoreText.alpha = 1f;
        }
        else {
            theSprite.sprite = XSprite;
            scoreText.alpha = 0f;
        }
    }
}
