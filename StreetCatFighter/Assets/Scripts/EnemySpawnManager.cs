using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject pigeon;
    //public Tilemap wall;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos;

        //���� 1-1����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(-37.5f, -35.5f), Random.Range(-0.5f, 17.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //���� 1-2����
        for (int i = 0; i < 3; i++)
        {
            spawnPos = new Vector3(Random.Range(-37.5f, -35.5f), Random.Range(-13.5f, -23.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 2-1����
        for (int i = 0; i < 3; i++)
        {
            spawnPos = new Vector3(Random.Range(-32.5f, -30.5f), Random.Range(15.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //���� 2-2����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(-32.5f, -30.5f), Random.Range(1.5f, -15.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 3����
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(-24.5f, -22.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 4����
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(-16.5f, -14.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 5����
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(-8.5f, -6.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 6-1����
        for (int i = 0; i < 3; i++)
        {
            spawnPos = new Vector3(Random.Range(-0.5f, 1.5f), Random.Range(10.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
        //���� 6-2����
        for (int i = 0; i < 7; i++)
        {
            spawnPos = new Vector3(Random.Range(-0.5f, 1.5f), Random.Range(4.5f, -27.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        //���� 7����
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(7.5f, 9.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }

        // ���� 8����
        for (int i = 0; i < 10; i++)
        {
            spawnPos = new Vector3(Random.Range(15.5f, 17.5f), Random.Range(-27.5f, 24.5f), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
