using UnityEngine;
using TMPro;

public class Enkaphalincounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private TextMeshProUGUI scoreText;
    int EndorphinsCollected = 0;
    private GameManager gameManger;
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EndorphinsCollected = gameManger.EndorphinsCollected;
        scoreText.text = "Endorphins collected : " +  EndorphinsCollected;
        
    }
}
