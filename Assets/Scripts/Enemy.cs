using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBullet;

    public delegate void SpawnEnemyBullet(GameObject enemyBullet); 
    public static event SpawnEnemyBullet OnBulletSpawn;
    
    //When an Enemy is Destroyed.
    public delegate void EnemyDestroyed(int pointValue);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    
    //Speed Up
    public delegate void EnemySpeedUp(float speedValue);

    public static event EnemySpeedUp OnEnemySpeedUp;

    public int score = 40;
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name is "Bullet(Clone)")
        {
            Debug.Log("Ouch!");
      
            OnEnemyAboutToBeDestroyed.Invoke(score);
            OnEnemySpeedUp.Invoke(0.2f);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void Start()
    {
        if (this.name is "Enemy 3(Clone)")
        {
            InvokeRepeating("EnemyBullet", 5, 5);
        }
    }

    private void Update()
    {
        if (this.name != "Enemy 4(Clone)")
        {
            Invoke("EnemyAnimate", 2);
        }
    }

    private void EnemyAnimate()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("isMoving");
    }

    private void EnemyBullet()
    {
        OnBulletSpawn.Invoke(enemyBullet);
    }
}
