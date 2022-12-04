using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    // �ð��� ����� ������ �ϳ� ������ش�.
    float currTime;
    [SerializeField]
    private GameObject[] itemPrefabs;
    // �ݺ��Ǵ� �۾��̹Ƿ� ������Ʈ �Լ� �ȿ��� �ڵ带 �Է��Ѵ�.

    void Update()
    {
        // �ð��� �帣�� ������ش�.
        currTime += Time.deltaTime;

        // ������Ʈ�� ���ʸ��� ������ ������ ���ǹ����� �����. ���⼭�� 10�ʷ� �ߴ�.
        if (currTime > 3)
        {
            // x,y,z ��ǥ���� ���� �ٸ� �������� �����ϰ� ���������� �������.
            //float newX = Random.Range(-10f, 10f), newY = Random.Range(-50f, 50f), newZ = Random.Range(-100f, 100f);
            float newX = Random.Range(-5f, 5f), newY = Random.Range(-5f, 5f), newZ = Random.Range(-5f, 5f);
            // ������ ������Ʈ�� �ҷ��´�.
            GameObject monster = Instantiate(itemPrefabs[0]);

            // �ҷ��� ������Ʈ�� �����ϰ� ������ ��ǥ������ ��ġ�� �ű��.
            itemPrefabs[0].transform.position = new Vector3(newX, newY, newZ);

            // �ð��� 0���� �ǵ����ָ�, 10�ʸ��� �ݺ��ȴ�.
            currTime = 0;
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
