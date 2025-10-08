using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text TxtScore;
    static public int Score;
    public int currentScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // currentScore = Score;
        TxtScore.text = "Score:" + Score;
    }
}
