using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int barrierHealth;
    // Start is called before the first frame update
    void Start()
    {
        barrierHealth = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name is "Bullet(Clone)" or "EnemyBullet(Clone)")
        {
            Debug.Log("Barrier Hit!");
            barrierHealth -= 1;
            if (barrierHealth <= 0)
            {
                Destroy(this.gameObject);
                Destroy(col.gameObject);
            }
        }
    }
}
