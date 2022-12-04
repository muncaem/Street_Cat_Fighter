using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpviewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHp playerHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderHP.value = playerHP.currentHP/playerHP.MaxHP;//slider에 현재 체력정보 업데이트
    }
}
