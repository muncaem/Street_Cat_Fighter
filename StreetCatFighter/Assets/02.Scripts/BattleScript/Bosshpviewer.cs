using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bosshpviewer : MonoBehaviour
{
    [SerializeField]
    private BossHp bossHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {
        // Slider UI�� ü�� ������ ������Ʈ
        sliderHP.value = bossHP.CurrentHP / bossHP.MaxHP;
    }
}
