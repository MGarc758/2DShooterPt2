using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBullet;
    public AudioSource splatSound;
    public AudioSource shootSound;
    private Animator animator;

    public delegate void SpawnEnemyBullet(GameObject enemyBullet, AudioSource shootSound); 
    public static event SpawnEnemyBullet OnBulletSpawn;
    
    //When an Enemy is Destroyed.
    public delegate void EnemyDestroyed(int pointValue);
    public static event EnemyDestroyed OnEnemyAboutToBeDestroyed;
    
    //Speed Up
    public delegate void EnemySpeedUp(float speedValue);

    public static event EnemySpeedUp OnEnemySpeedUp;

    public int score = 40;
    private static readonly int IsDead = Animator.StringToHash("isDead");

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name is not "Bullet(Clone)") return;
        Debug.Log("Ouch!");
        splatSound.Play();
        
        animator.SetBool("isDead", true);

        OnEnemyAboutToBeDestroyed.Invoke(score);
        OnEnemySpeedUp.Invoke(0.2f);
        Invoke("destroySelf", 1f);
        Destroy(collision.gameObject);
    }

    private void destroySelf()
    {
        Destroy(this.gameObject);
    }
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (this.name is "Enemy 3(Clone)")
        {
            InvokeRepeating("EnemyBullet", 5, 5);
        }
        
    }

    private void Update()
    {
        
    }

    private void EnemyAnimate()
    {
        animator.SetTrigger("isMoving");
    }

    private void EnemyBullet()
    {
        OnBulletSpawn.Invoke(enemyBullet, shootSound);
    }
}
