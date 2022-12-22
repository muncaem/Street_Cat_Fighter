using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject pigeon;
    int total_enemyNum = 80;
    int spot_enemyNum = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(spot_enemyNum);
    }

    // Update is called once per frame
    void Update()
    {
        RespawnEnemy();
    }

    void SpawnEnemy(int num) 
    {
        Vector3 spawnPos;

        //技肺 1-1备开
        for (int i = 0; i < num/2; i++)
        {
            spawnPos = new Vector3(Random.Range(-37.5f, -35.5f), Random.Range(-0.5f, 17.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //技肺 1-2备开
        for (int i = 0; i < num / 2; i++)
        {
            spawnPos = new Vector3(Random.Range(-37.5f, -35.5f), Random.Range(-13.5f, -23.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 2-1备开
        for (int i = 0; i < num / 2; i++)
        {
            spawnPos = new Vector3(Random.Range(-32.5f, -30.5f), Random.Range(15.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //技肺 2-2备开
        for (int i = 0; i < num / 2; i++)
        {
            spawnPos = new Vector3(Random.Range(-32.5f, -30.5f), Random.Range(1.5f, -15.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 3备开
        for (int i = 0; i < num; i++)
        {
            spawnPos = new Vector3(Random.Range(-24.5f, -22.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 4备开
        for (int i = 0; i < num; i++)
        {
            spawnPos = new Vector3(Random.Range(-16.5f, -14.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 5备开
        for (int i = 0; i < num; i++)
        {
            spawnPos = new Vector3(Random.Range(-8.5f, -6.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 6-1备开
        for (int i = 0; i < num/2; i++)
        {
            spawnPos = new Vector3(Random.Range(-0.5f, 1.5f), Random.Range(10.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //技肺 6-2备开
        for (int i = 0; i < num/2; i++)
        {
            spawnPos = new Vector3(Random.Range(-0.5f, 1.5f), Random.Range(4.5f, -27.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //技肺 7备开
        for (int i = 0; i < num; i++)
        {
            spawnPos = new Vector3(Random.Range(7.5f, 9.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        // 技肺 8备开
        for (int i = 0; i < num; i++)
        {
            spawnPos = new Vector3(Random.Range(15.5f, 17.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
    }

    void RespawnEnemy() 
    {
        int EnemyNum = 0;

        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < Enemies.Length; i++) 
        {
            EnemyNum++;
        }

        if (EnemyNum <= (total_enemyNum /= 2)) 
        {
            SpawnEnemy(spot_enemyNum/2);
        }
    }
}
