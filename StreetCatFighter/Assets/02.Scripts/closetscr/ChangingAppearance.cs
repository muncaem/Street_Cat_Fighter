using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingAppearance : MonoBehaviour
{
    public SpriteRenderer part; //드롭 드래그되어 무기 보임
    public Sprite[] options;
    public int index;

    void Update()
    {
        for (int i = 0; i < options.Length; i++)
        {
            if (i == index)
            {
                part.sprite = options[i];
            }
        }
    }

    public void Swap()
    {
        if (index < options.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }
    }
}