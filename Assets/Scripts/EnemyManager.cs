using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    
    //number of rows per enemy Prefab
    public int rowCount;
    
    public Transform environmentRoot;

    //for Spawning Enemies
    private GameObject[] enemyPrefabs;
    private int columnCount = 4;
    public int spacingY;
    public int spacingX;
    private float spawnPointX;
    
    //for Moving Enemies
    public float speed;
    private bool isEnemyMovingRight = true;
    private float boundaryX;
    private float currentX;
    private float enemyMovementX;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.OnBulletSpawn += EnemyOnBulletSpawn;
        Enemy.OnEnemySpeedUp += EnemySpeedUp;
        enemyPrefabs = new[] { enemy1Prefab, enemy2Prefab, enemy3Prefab, enemy4Prefab};

        spawnPointX = environmentRoot.position.x;
        Vector3 position = environmentRoot.position;

        currentX = spawnPointX;
        boundaryX = 4.72f;

        int rowLength = rowCount;
        foreach (var enemy in enemyPrefabs)
        {
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var newEnemy = Instantiate(enemy, position, Quaternion.identity);
                    newEnemy.transform.SetParent(environmentRoot);

                    position.x += spacingX;
                }
            }

            position.x = spawnPointX;
            position.y += spacingY;
        }

        spawnPointX = -9.72f;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovementX = speed * Time.deltaTime;
        // Debug.Log($"enemyMovement:{enemyMovementX}\n currentX:{currentX}\n boundaryX:{boundaryX}\n spawnPointX:{spawnPointX}");
        if (isEnemyMovingRight)
        {
            currentX += enemyMovementX;
            if (currentX < boundaryX)
            {
                environmentRoot.Translate(enemyMovementX, 0, 0);
            }
            else
            {
                isEnemyMovingRight = !isEnemyMovingRight;
                environmentRoot.Translate(0, -spacingY, 0);

            }
        }
        else
        {
            currentX -= enemyMovementX;
            if (currentX > spawnPointX)
            {
                environmentRoot.Translate(-enemyMovementX, 0, 0);
            }
            else
            {
                isEnemyMovingRight = !isEnemyMovingRight;
                environmentRoot.Translate(0, -spacingY, 0);

            }
        }
    }

    private void EnemyOnBulletSpawn(GameObject enemyBullet)
    {
        int random = Random.Range(0, 4);
        if (random == 1)
        {
            Vector3 bulletSpawn = GetComponent<Transform>().position;
            bulletSpawn.y = environmentRoot.position.y;
            bulletSpawn.z = 0f;
            GameObject shot = Instantiate(enemyBullet, bulletSpawn, Quaternion.identity);
            
            Debug.Log("Bang!");
        }
    }

    private void EnemySpeedUp(float speedValue)
    {
        speed += speedValue;
    }
}
