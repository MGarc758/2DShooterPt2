using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnEnemyAboutToBeDestroyed += EnemyOnEnemyAboutToBeDestroyed;
    }

    private void EnemyOnEnemyAboutToBeDestroyed(float pointValue)
    {
        Debug.Log($"enemy destroyed: Worth {pointValue} points");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
