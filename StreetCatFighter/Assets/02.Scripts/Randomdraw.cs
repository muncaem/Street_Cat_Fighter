using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomdraw : MonoBehaviour
{
    //Player bring_coin;
    public int total = 0;//0
    int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };//����ġ Ȯ��
    // Ȱ��ȭ,��Ȱ��ȭ �� ������Ʈ

    //public GameObject DrawShop; // �̱� �����۳���(���Ǳ� ĸ��)
    public GameObject DrawWindow; // �̴� â

    // �ҷ��� �̹��� ������Ʈ
    public Image DrawImage; // ���� �̹����� ����� ������Ʈ

    //���� �̹���
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

    // ������ �̹��� ����
    public int RandomInt; // ���� ����

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
        //RandomInt = Random.Range(0, 10); // ���� ������ ����
        //RandomInt = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));//0
        
    }

    public void OneDraw() // 1ȸ �̱� ��ư�� Ŭ�� ��
    {
        Player bring_coin = GameObject.Find("Player").GetComponent<Player>();//�÷��̾��� ���� ���� ����������

        Randomdraw bringing = GetComponent<Randomdraw>();
        //int item_cost = 0;
        //int.TryParse(bringing.costbring, out item_cost);

        //DrawShop.SetActive(false); //�̱� ���� ȭ���� ��Ȱ��ȭ
        DrawWindow.SetActive(true);// ���� �̹����� ����� ȭ���� Ȱ��ȭ
        RandomInt = GetRandomindex();
        if (RandomInt == 1) // RandomInt�� 1�̶��
        {
            DrawImage.sprite = Image1; // DrawImage�� Sprite�� Image1(Sprite)�� ����
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
        Invoke("CloseDraw", 2.0f); // 2�� �ڿ� CloseDraw �Լ��� ����

        Debug.Log(RandomInt);
    }

    public void CloseDraw() // �̱� ��ũ��Ʈ�� ����ǰ� �ڵ����� ����
    {
        DrawImage.sprite = null; // �����ߴ� �̹����� �ʱ�ȭ
        //DrawShop.SetActive(true); // �̱� ���� ȭ���� Ȱ��ȭ �ϰ�,
        DrawWindow.SetActive(false); // ���� �̹��� ȭ���� ��Ȱ��ȭ
        
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
