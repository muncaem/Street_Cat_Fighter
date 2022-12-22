using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerkeep : MonoBehaviour
{
    public static Playerkeep instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}