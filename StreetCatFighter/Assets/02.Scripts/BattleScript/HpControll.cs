using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControll : MonoBehaviour
{
    public List<Transform> obj;
    public List<GameObject> hp_bar;

    Camera camera_1;
    // Start is called before the first frame update
    void Start()
    {
        camera_1 = Camera.main;
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = obj[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = camera_1.WorldToScreenPoint(obj[i].position + new Vector3(0, 1.5f, 0));
        }
    }
}