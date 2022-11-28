using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject fish;
    public GameObject coin;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 0);
            Instantiate(fish, spawnPos, transform.rotation);
        }

        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 0);
            Instantiate(coin, spawnPos, transform.rotation);
        }

        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 0);
            Instantiate(box, spawnPos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}