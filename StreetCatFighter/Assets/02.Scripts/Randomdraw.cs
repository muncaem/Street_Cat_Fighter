using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomdraw : MonoBehaviour
{
    //Player bring_coin;
    public int total = 0;//0
    int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };//가중치 확률
    // 활성화,비활성화 할 오브젝트

    //public GameObject DrawShop; // 뽑기 아이템나열(자판기 캡슐)
    public GameObject DrawWindow; // 뽑는 창

    // 불러올 이미지 오브젝트
    public Image DrawImage; // 랜덤 이미지를 출력할 오브젝트

    //숫자 이미지
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;
    public Sprite Image7;
    public Sprite Image8;
    public Sprite Image9;
    public Sprite Image10;
    public Sprite Image11;
    public Sprite Image12;
    public Sprite Image13;
    public Sprite Image14;

    // 아이템 이미지 변수
    public int RandomInt; // 랜덤 변수

    public GameObject bring_coin;

    List<Image> invenbaseImg = new List<Image>();
    int invenCount, invennum;

    void Start()//0
    {
        for (int i = 0; i < weights.Length; i++)
        {
            total += weights[i];
        }

        

    }

    void Update()
    {
        //RandomInt = GetRandomindex();
        //RandomInt = Random.Range(0, 10); // 랜덤 범위를 설정
        //RandomInt = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));//0
        
    }

    public void OneDraw() // 1회 뽑기 버튼을 클릭 시
    {
        Player bring_coin = GameObject.Find("Player").GetComponent<Player>();//플레이어의 현재 코인 수가져오기

        Randomdraw bringing = GetComponent<Randomdraw>();
        //int item_cost = 0;
        //int.TryParse(bringing.costbring, out item_cost);

        //DrawShop.SetActive(false); //뽑기 선택 화면을 비활성화
        DrawWindow.SetActive(true);// 랜덤 이미지를 출력한 화면을 활성화
        RandomInt = GetRandomindex();
        if (RandomInt == 1) // RandomInt가 1이라면
        {
            DrawImage.sprite = Image1; // DrawImage의 Sprite에 Image1(Sprite)를 적용
            bring_coin.coin += 10;
            bring_coin.coinNum.text = bring_coin.coin.ToString(); 
        }
        else if (RandomInt == 2)
        {
            DrawImage.sprite = Image2;
            bring_coin.coin += 5;
            bring_coin.coinNum.text = bring_coin.coin.ToString(); 
        }
        else if (RandomInt == 3)
        {
            DrawImage.sprite = Image3;
            bring_coin.coin += 1;
            bring_coin.coinNum.text = bring_coin.coin.ToString();
        }
        else if (RandomInt == 4)
        {
            DrawImage.sprite = Image4;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 5)
        {
            DrawImage.sprite = Image5;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 6)
        {
            DrawImage.sprite = Image6;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 7)
        {
            DrawImage.sprite = Image7;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 8)
        {
            DrawImage.sprite = Image8;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }

        }
        else if (RandomInt == 9)
        {
            DrawImage.sprite = Image9;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 10)
        {
            DrawImage.sprite = Image10;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }

        else if (RandomInt == 11)
        {
            DrawImage.sprite = Image11;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 12)
        {
            DrawImage.sprite = Image12;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 13)
        {
            DrawImage.sprite = Image13;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        else if (RandomInt == 14)
        {
            DrawImage.sprite = Image14;
            if (1 < invennum && invennum < 3)
            {
                invennum += 1;

                invenbaseImg[invenCount].sprite = bringing.DrawImage.GetComponent<SpriteRenderer>().sprite;
                invenbaseImg[invenCount].gameObject.SetActive(true);
                invenCount++;
            }
        }
        Invoke("CloseDraw", 2.0f); // 2초 뒤에 CloseDraw 함수를 실행

        Debug.Log(RandomInt);
    }

    public void CloseDraw() // 뽑기 스크립트가 실행되고 자동으로 실행
    {
        DrawImage.sprite = null; // 적용했던 이미지를 초기화
        //DrawShop.SetActive(true); // 뽑기 선택 화면을 활성화 하고,
        DrawWindow.SetActive(false); // 랜덤 이미지 화면을 비활성화
        
    }

    private int GetRandomindex()
    {
        
        int pivot = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));
        int weight = 0;

        for(int i=0;i<weights.Length; ++i)
        {
            weight += weights[i];
            if(pivot <= weight) 
            {
                return i;
            }
        }
        return 0;
    }
}
