using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject pigeon;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-3, 3), Random.Range(-4, 4), 1);
            Instantiate(pigeon, spawnPos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
