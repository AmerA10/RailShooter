using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
 
    int score;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreHit(int enemyScore)
    {
        score = score + enemyScore;
        scoreText.text = score.ToString();
    }
}
