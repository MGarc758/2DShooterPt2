using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    private int score;
    private int highScore;
    
    void Start()
    {
        score = 0;
        highScore = 0;
        
        Enemy.OnEnemyAboutToBeDestroyed += EnemyOnEnemyAboutToBeDestroyed;
    }

    private void EnemyOnEnemyAboutToBeDestroyed(int pointValue)
    {
        score += pointValue;
        Debug.Log($"enemy destroyed: Worth {pointValue} points");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (score < 10)
        {
            scoreText.text = "Score\n000" + score.ToString();
        } else if (score < 100)
        {
            scoreText.text = "Score\n00" + score.ToString();
        } else if (score < 1000)
        {
            scoreText.text = "Score\n0" + score.ToString();
        }
        else
        {
            scoreText.text = "Score\n" + score.ToString();
        }

        if (score > highScore)
        {
            highScore = score;
        }
        
        if (highScore < 10)
        {
            highScoreText.text = "High Score\n000" + score.ToString();
        } else if (highScore < 100)
        {
            highScoreText.text = "High Score\n00" + score.ToString();
        } else if (highScore < 1000)
        {
            highScoreText.text = "High Score\n0" + score.ToString();
        }
        else
        {
            highScoreText.text = "High Score\n" + score.ToString();
        }
    }
}
