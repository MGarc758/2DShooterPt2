using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void EnemyDestroyed(float pointValue);

    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;

    public int score = 40;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      
      OnEnemyAboutToBeDestroyed.Invoke(score);
      Destroy(this.gameObject);
    }
}
