using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject bronzeCoin;
    public GameObject silverCoin;
    public GameObject goldCoin;

    public GameObject fish;

    public GameObject box;

    Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        //���� 1-1����
        for (int i = 0; i < 2; i++)
        {
            spawnPos = new Vector3(Random.Range(-37, -35), Random.Range(5, 15), 1);
            SpawnBronzeCoin_ver();
        }
        //���� 1-2����
        for (int i = 0; i < 1; i++)
        {
            spawnPos = new Vector3(Random.Range(-37, -35), Random.Range(-16, -18), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 2-1����
        for (int i = 0; i < 1; i++)
        {
            spawnPos = new Vector3(Random.Range(-32, -30), Random.Range(18, 25), 1);
            SpawnBronzeCoin_ver();
        }
        //���� 2-2����
        for (int i = 0; i < 1; i++)
        {
            spawnPos = new Vector3(Random.Range(-32, -30), Random.Range(-13, -1), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 3����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(-24, -22), Random.Range(-25, 25), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 4����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(-16, -14), Random.Range(-25, 25), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 5����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(-8, -6), Random.Range(-25, 25), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 6-1����
        for (int i = 0; i < 1; i++)
        {
            spawnPos = new Vector3(Random.Range(0, 2), Random.Range(16, 25), 1);
            SpawnBronzeCoin_ver();
        }
        //���� 6-2����
        for (int i = 0; i < 2; i++)
        {
            spawnPos = new Vector3(Random.Range(0, 2), Random.Range(5, -25), 1);
            SpawnBronzeCoin_ver();
        }

        //���� 7����
        for (int i = 0; i < 5; i++)
        {

            spawnPos = new Vector3(Random.Range(8, 10), Random.Range(-25, 25), 1);
            SpawnBronzeCoin_ver();
        }

        // ���� 8����
        for (int i = 0; i < 5; i++)
        {
            spawnPos = new Vector3(Random.Range(16, 18), Random.Range(-25, 25), 1);
            SpawnBronzeCoin_ver();
        }

        // ���� 1����
        for (int i = 0; i < 1; i++)
        {
            spawnPos = new Vector3(Random.Range(-35, -27), Random.Range(-23, -21), 1);
            SpawnBronzeCoin_hor();
        }

        /*// ���� ���� ����1
        spawnPos = new Vector3(Random.Range(-37, -25), Random.Range(-21, -23), 1);
        Instantiate(fish, new Vector3(spawnPos.x - 0.5f, spawnPos.y - 0.5f, spawnPos.z), transform.rotation);

        // ���� ���� ����2
        spawnPos = new Vector3(Random.Range(-13, -9), Random.Range(10, 7), 1);
        Instantiate(fish, new Vector3(spawnPos.x - 0.5f, spawnPos.y - 0.5f, spawnPos.z), transform.rotation);*/
    }

    void SpawnBronzeCoin_ver()
    {
        Instantiate(bronzeCoin, new Vector3(spawnPos.x - 0.5f, spawnPos.y + 0.5f, spawnPos.z), transform.rotation);
        Instantiate(bronzeCoin, new Vector3(spawnPos.x - 0.5f, spawnPos.y - 0.5f, spawnPos.z), transform.rotation);
        Instantiate(bronzeCoin, new Vector3(spawnPos.x - 0.5f, spawnPos.y - 1.5f, spawnPos.z), transform.rotation);
    }

    void SpawnBronzeCoin_hor()
    {
        Instantiate(bronzeCoin, new Vector3(spawnPos.x + 0.5f , spawnPos.y - 0.5f, spawnPos.z), transform.rotation);
        Instantiate(bronzeCoin, new Vector3(spawnPos.x + 1.5f, spawnPos.y - 0.5f, spawnPos.z), transform.rotation);
        Instantiate(bronzeCoin, new Vector3(spawnPos.x + 2.5f, spawnPos.y - 0.5f, spawnPos.z), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}