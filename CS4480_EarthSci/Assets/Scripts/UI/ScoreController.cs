using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public static ScoreController _instance;
    public TMP_Text text;
    public int score = 100;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        text.text = "Score: " + score;
    }
    public void AdjustScore(int amount){
        score += amount;
        score = Mathf.Max(0,score);
        text.text = "Score: " +score;
    }
}
