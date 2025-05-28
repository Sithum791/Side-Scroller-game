using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score :" + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int coinvalue)
    {
        score += coinvalue;
        scoreText.text = "Score :" + score.ToString();
    }
}
